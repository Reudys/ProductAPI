using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Interfaces;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service) { _service = service; }

        [HttpPost("Create")]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            await _service.CreateAsync(product);
            return Ok(product);
        }

        [HttpGet("Products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<Product>> Update(int id, Product product) 
        { 
            var prod = await _service.UpdateAsync(id, product);
            return Ok(prod);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id) 
        { 
            await _service.DeleteAsync(id);
            return Ok(true);
        }

        [HttpPatch("Stock/{id}")]
        public async Task<IActionResult> UpdateStock(int id, int newStock)
        {
            await _service.UpdateStockAsync(id, newStock);
            return Ok(newStock);
        }
    }
}
