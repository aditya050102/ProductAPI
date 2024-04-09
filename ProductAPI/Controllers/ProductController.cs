using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Service;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public ProductService productService { get; set; }
        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost("addProduct")]
        public async Task<ActionResult<Products>> AddAsync(Products product)
        {
            return await productService.AddAsync(product);
        }

        [HttpGet("deleteProduct")]
        public async Task<ActionResult<Products>> DeleteAsync(Guid id)
        {
            return await productService.DeleteAsync(id);
        }

        [HttpGet("getAllProducts")]
        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await productService.GetAllAsync();
        }

        [HttpGet("getProduct")]
        public async Task<ActionResult<Products>> GetAsync(Guid id)
        {
            return await productService.GetAsync(id);
        }

        [HttpPut("updateProduct")]
        public async Task<ActionResult<Products>> UpdateAsync(Products product)
        {
            return await productService.UpdateAsync(product);
        }
    }
}
