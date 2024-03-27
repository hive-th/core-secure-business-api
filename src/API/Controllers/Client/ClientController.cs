using Core.Secure.Business.Domain.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Core.Secure.Business.API.Controllers.Client;

//Member login only
[Route("client")]
[ApiController]
public partial class ClientController : ControllerBase
{
    private readonly ICartService _cartService;

    public ClientController(ICartService cartService)
    {
        _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
    }
}