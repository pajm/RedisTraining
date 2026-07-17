using Microsoft.AspNetCore.Mvc;
using RedisTraining.Application.Interfaces;
using RedisTraining.Application.Models;

namespace RedisTraining.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        public async Task<IActionResult> Set(Product product)
        {
            await _productService.SetProductAsync(product);

            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
