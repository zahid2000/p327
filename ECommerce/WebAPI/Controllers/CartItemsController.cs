using ECommerce.Business.Abstract;
using ECommerce.Entities.Dtos.CartItems;
using ECommerce.Entities.Dtos.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemsController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _cartItemService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CartItemCreateDto createDto)
        {
            var result = await _cartItemService.AddAsync(createDto);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
    }
}
