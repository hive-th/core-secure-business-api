using Core.DotNet.AggregatesModel.CommonAggregate;
using Core.DotNet.AggregatesModel.ExceptionAggregate;
using Core.DotNet.Domain.Services;
using Core.DotNet.Extensions.Utilities;
using Core.DotNet.Extensions.Validations;
using Core.DotNet.Infrastructure;
using Core.DotNet.Utilities.Auth;
using Core.Secure.Business.Domain.AggregatesModel.CartAggregate;
using Core.Secure.Business.Domain.AggregatesModel.CartAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.CommonAggregate;
using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;
using Core.Secure.Business.Domain.AggregatesModel.OrderAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.BPAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.ProductAggregate.Interface;
using Core.Secure.Business.Domain.Extensions.CommonAggregate;
using Core.Secure.Business.Domain.Services.Interface;
using Core.Secure.Business.Domain.Validations.CartValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Core.Secure.Business.Domain.Services;

public class CartService : ICartService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICacheService _cacheService;
    private readonly IBPRepository _bpRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderRequestRepository _orderRequestRepository;
    private readonly IOrderService _orderService;
    
    public CartService(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        ICacheService cacheService,
        IBPRepository bpRepository,
        IProductRepository productRepository,
        ICartRepository cartRepository,
        IOrderRepository orderRepository,
        IOrderRequestRepository orderRequestRepository,
        IOrderService orderService
    )
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
        _bpRepository = bpRepository ?? throw new ArgumentNullException(nameof(bpRepository));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _orderRequestRepository = orderRequestRepository ?? throw new ArgumentNullException(nameof(orderRequestRepository));
        _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
    }

    public async Task<CreateCartResponse> CreateCartAsync(CreateCartRequest request)
    {
        var module = "create_cart";
        #region Data Validation
        
        var validationResult = await new CreateCartRequestValidator().ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new CustomHttpBadRequestException(module, validationResult.Errors.ToErrorFields(),
                "invalid_input", "Invalid input");
    
        #endregion Data Validation
        
        var guidId = Guid.NewGuid();
        Cart cart;
        try
        {
            // ถ้าเป็น Guest แล้วกดสั่งซื้อ แล้วบังคับให้ login ต้องไปทำตัวเช็คแมบ ping รอไปก่อน ค่อยกลับมาทำ
            if (_httpContextAccessor.HasAuthorization())
            {
                if (!request.CartId.IsNullOrEmpty())
                {
                    cart = await _cartRepository.GetCartByIdAsync(request.CartId.ToGuidResponse()) ?? new Cart
                    {
                        Id = guidId,
                        CartType = CartType.LOGGED_IN_USER,
                        BuyerId = _httpContextAccessor.GetUserId().ToGuidResponse(),
                        GuestId = ""
                    };
                }
                else
                {
                    cart = await _cartRepository.GetCartByUserIdAsync(_httpContextAccessor.GetUserId()) ?? new Cart
                    {
                        Id = guidId,
                        CartType = CartType.LOGGED_IN_USER,
                        BuyerId = _httpContextAccessor.GetUserId().ToGuidResponse(),
                        GuestId = ""
                    };
                }
            }
            else
            {
                cart = new Cart
                {
                    Id = guidId,
                    CartType = CartType.GUEST_USER,
                    BuyerId = new Guid(),
                    GuestId = request.GuestId
                };
            }
        
            var vendorDealer = await _bpRepository.GetVendorByIdAsync(request.DealerId.ToGuidResponse());
            if (vendorDealer is null)
                throw new CustomHttpBadRequestException(module, "not_found", "The dealer not found.");

            var product = await _productRepository.GetProductByIdAsync(request.ProductId.ToGuidResponse());
            if (product is null)
                throw new CustomHttpBadRequestException(module, "not_found", "The product not found.");

            decimal subTotal = 0;
            decimal totalAmount = 0;
            int totalItem = 0;
            
            if (cart.Dealers is null)
            {
                //new cart only
                var dealer = new Dealer
                {
                    Id = vendorDealer.Id.ToString(),
                    Name = vendorDealer.Name.XX,
                    IsRegister = false,///check customer and  dealer api this ok?
                    Logo = new Image
                    {
                        Extension = null,
                        BaseUri = null,
                        FilePath = null
                    },
                    ProductItems = new List<ProductItem>()
                };
                
                var productMaker = new ProductMaker();
                var maker = await _bpRepository.GetVendorByIdAsync(product.MakerId.ToGuidResponse());
                if (maker is not null)
                {
                    productMaker.MakerId = maker.Id.ToString();
                    productMaker.MakerName = maker.Name.XX;
                }

                var productPriceUnit = product.ProductPriceUnit.First(m => m.Unit.Id.Equals(request.UnitId.ToGuidResponse()));
                dealer.ProductItems.Add(new ProductItem
                {
                    Id = product.Id,
                    Name = product.Name.XX,
                    Logo = new Image
                    {
                        Extension = null,
                        BaseUri = null,
                        FilePath = null
                    },
                    Maker = productMaker,
                    SKU = product.Sku,
                    PreOrderType = product.PreOrderMode,
                    Unit = new ProductUnit
                    {
                        Id = productPriceUnit.Unit.Id.ToString(),
                        Name = productPriceUnit.Unit.Name.XX
                    },
                    UnitPrice = productPriceUnit.Price,//1. login? 2.register? 3.tier price
                    Qty = request.Quantity,
                    Price = productPriceUnit.Price * request.Quantity
                });
                
                foreach (var p in dealer.ProductItems)
                {
                    subTotal = subTotal + p.Price;
                    totalAmount = totalAmount + p.Price;
                    totalItem = totalItem + 1;
                }

                cart.Dealers = new List<Dealer> { dealer };
                cart.Summary = new Summary
                {
                    SubTotal = subTotal,
                    Discount = 0,
                    Vat = 0,
                    Items = totalItem,
                    TotalAmount = totalAmount
                };
        
                _cartRepository.Insert(cart);
                
            }//if dealer
            else
            {
                var dealerOld = cart.Dealers.FirstOrDefault(m => m.Id.Equals(request.DealerId));
                if (dealerOld is not null)
                {
                    //old dealer
                    var productMaker = new ProductMaker();
                    var maker = await _bpRepository.GetVendorByIdAsync(product.MakerId.ToGuidResponse());
                    if (maker is not null)
                    {
                        productMaker.MakerId = maker.Id.ToString();
                        productMaker.MakerName = maker.Name.XX;
                    }
                        
                    var productPriceUnit = product.ProductPriceUnit.First(m => m.Unit.Id.Equals(request.UnitId.ToGuidResponse()));
                    dealerOld.ProductItems.Add(new ProductItem
                    {
                        Id = product.Id,
                        Name = product.Name.XX,
                        Logo = new Image
                        {
                            Extension = null,
                            BaseUri = null,
                            FilePath = null
                        },
                        Maker = productMaker,
                        SKU = product.Sku,
                        PreOrderType = product.PreOrderMode,
                        Unit = new ProductUnit
                        {
                            Id = productPriceUnit.Unit.Id.ToString(),
                            Name = productPriceUnit.Unit.Name.XX
                        },
                        UnitPrice = productPriceUnit.Price,//1. login? 2.register? 3.tier price
                        Qty = request.Quantity,
                        Price = productPriceUnit.Price * request.Quantity
                    });
                }
                else
                {
                    //new dealer
                    var dealerNew = new Dealer
                    {
                        Id = vendorDealer.Id.ToString(),
                        Name = vendorDealer.Name.XX,
                        IsRegister = false,///check customer and  dealer api this ok?
                        Logo = new Image
                        {
                            Extension = null,
                            BaseUri = null,
                            FilePath = null
                        },
                        ProductItems = new List<ProductItem>()
                    };
                    
                    var productMaker = new ProductMaker();
                    var maker = await _bpRepository.GetVendorByIdAsync(product.MakerId.ToGuidResponse());
                    if (maker is not null)
                    {
                        productMaker.MakerId = maker.Id.ToString();
                        productMaker.MakerName = maker.Name.XX;
                    }
                    
                    var productPriceUnit = product.ProductPriceUnit.First(m => m.Unit.Id.Equals(request.UnitId.ToGuidResponse()));
                    dealerNew.ProductItems.Add(new ProductItem
                    {
                        Id = product.Id,
                        Name = product.Name.XX,
                        Logo = new Image
                        {
                            Extension = null,
                            BaseUri = null,
                            FilePath = null
                        },
                        Maker = productMaker,
                        SKU = product.Sku,
                        PreOrderType = product.PreOrderMode,
                        Unit = new ProductUnit
                        {
                            Id = productPriceUnit.Unit.Id.ToString(),
                            Name = productPriceUnit.Unit.Name.XX
                        },
                        UnitPrice = productPriceUnit.Price,//1. login? 2.register? 3.tier price
                        Qty = request.Quantity,
                        Price = productPriceUnit.Price * request.Quantity
                    });
                    cart.Dealers.Add(dealerNew);
                }
                
                foreach (var p in cart.Dealers.SelectMany(item => item.ProductItems))
                {
                    subTotal = subTotal + p.Price;
                    totalAmount = totalAmount + p.Price;
                    totalItem = totalItem + 1;
                }
                
                cart.Summary.SubTotal = subTotal;
                cart.Summary.TotalAmount = totalAmount;
                cart.Summary.Items = totalItem;
                _cartRepository.Update(cart);
            }
            _unitOfWork.SaveChanges();
        }
        catch (Exception e)
        {
            if (e.Source.Equals("Microsoft.EntityFrameworkCore.Relational"))
                throw new CustomHttpBadRequestException(module, "duplicate_data" , e.Message);
        
            throw e;
        }
        
        return new CreateCartResponse
        {
            Id = cart.Id,
            GuestId = cart.GuestId
        };
    }

    public Task<CartResponse> GetCartAsync(Guid cartId)
    {
        throw new NotImplementedException();
    }

    public Task<CartResponse> MappingGuestUserAsync(string guestId)
    {
        throw new NotImplementedException();
    }

    public Task<List<CartValidationResponse>> ValidateCartOnPlaceOrderAsync(Guid cartId)
    {
        throw new NotImplementedException();
    }
}