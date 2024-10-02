using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.MohamedBassem.Domain.Services.Contract;

namespace Store.MohamedBassem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpGet] // Get / BaseUrl/Products
        public async Task<IActionResult> GetAllProducts() // endpoint
        {
            var result = await _productServices.GetAllProductsAsync();
            return Ok(result); 
        }
      
        [HttpGet("brands")] // Get / BaseUrl/Products/brands
        public async Task<IActionResult> GetAllBrands() // endpoint
        {
            var result = await _productServices.GetAllBrandsAsync();
            return Ok(result);
        }

        [HttpGet("types")] // Get / BaseUrl/Products/types
        public async Task<IActionResult> GetAllTypes() // endpoint
        {
            var result = await _productServices.GetAllTypesAsync();
            return Ok(result);
        }

        [HttpGet("id")] // Get / BaseUrl/Products/id
        public async Task<IActionResult> GetProductById(int? id) // endpoint
        {
            if (id is null)
            {
                return BadRequest("Invalid id !!");
            }
            var result = await _productServices.GetProudctById(id.Value);
            
            if (result is null)
            {
                return NotFound($"The Product With Id : {id} not Found at Data Base :(");
            }

            return Ok(result);
        }
    }
}
