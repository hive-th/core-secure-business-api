using Core.DotNet.AggregatesModel.CommonAggregate;
using Core.Secure.Business.Domain.AggregatesModel.CartAggregate;
using Core.Secure.Business.Domain.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Secure.Business.API.Controllers;

[ApiController]
[Route("cart")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
    }
    
    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(CreateCartResponse), 200)]
    public async Task<IActionResult> CreateCartAsync([FromBody] CreateCartRequest request)
    {
        var result = await _cartService.CreateCartAsync(request);

        return Ok(result);
    }
    
    [Authorize]
    [HttpGet("{cartId:guid}")]
    [ProducesResponseType(typeof(CartResponse), 200)]
    public async Task<IActionResult> GetCartAsync([FromRoute] Guid cartId)
    {
        var result = await _cartService.GetCartAsync(cartId);

        return Ok(result);
    }
    
    
    // [Authorize]
    // [HttpPost("mapping/{guestId:string}/guest")]
    // [ProducesResponseType(typeof(CreateResponse), 200)]
    // public async Task<IActionResult> MappingGuestUserAsync([FromRoute] string guestId)
    // {
    //     var result = await _cartService.MappingGuestUserAsync(guestId);
    //
    //     return Ok(result);
    // }
    

}