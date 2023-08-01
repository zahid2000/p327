using Core.Utilities.Results.Concrete;
using ECommerce.Business.Abstract;
using ECommerce.Entities.Concrete;
using ECommerce.Entities.Dtos.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result=await _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProductCreateDto productDto)
        {
          var result=  await _productService.Add(productDto);
            if (result.Success)
            {
            return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
         var result=  await _productService.Update(productDto);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
    }
}
