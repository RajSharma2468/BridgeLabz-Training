using Microsoft.AspNetCore.Mvc;
using SimpleCrudAPI.Entity;
using SimpleCrudAPI.Services;

namespace SimpleCrudAPI.Controllers
{
    // Handles product HTTP requests
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // Service instance used here
        private readonly ProductService productService = new ProductService();

        // GET api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = productService.GetAllProducts();
            return Ok(products);
        }

        // GET api/products/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = productService.GetProductById(id);
            if (product == null)
                return NotFound($"Product with id {id} not found.");

            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            productService.AddProduct(product);
            return Ok("Product created successfully.");
        }

        // PUT api/products/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            product.ProductId = id;
            productService.UpdateProduct(product);
            return Ok("Product updated successfully.");
        }

        // DELETE api/products/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productService.DeleteProduct(id);
            return Ok("Product deleted successfully.");
        }
    }
}