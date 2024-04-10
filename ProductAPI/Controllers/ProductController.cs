using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductAPI.Models;
using ProductAPI.Service;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpPost("addProduct")]
        public async Task<ActionResult<Products>> AddAsync(Products product)
        {
            if (product == null)
            {
                return BadRequest("Product data is null");
            }

            var addedProduct = await productService.AddAsync(product);

            return Ok(addedProduct);
        }

        [HttpGet("deleteProduct")]
        public async Task<ActionResult<Products>> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid product ID");
            }

            var deletedProduct = await productService.DeleteAsync(id);

            if (deletedProduct == null)
            {
                return NotFound();
            }

            return Ok(deletedProduct);
        }

        [HttpGet("getAllProducts")]
        public async Task<ActionResult<IEnumerable<Products>>> GetAllAsync()
        {
            var products = await productService.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("getProduct")]
        public async Task<ActionResult<Products>> GetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid product ID");
            }

            var product = await productService.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("updateProduct")]
        public async Task<ActionResult<Products>> UpdateAsync(Products product)
        {
            if (product == null)
            {
                return BadRequest("Product data is null");
            }

            var updatedProduct = await productService.UpdateAsync(product);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }
    }
}



























































































//using Microsoft.AspNetCore.Mvc;
//using ProductAPI.Models;
//using ProductAPI.Service;

//namespace ProductAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductController : Controller
//    {
//        public ProductService productService { get; set; }
//        public ProductController(ProductService productService)
//        {
//            this.productService = productService;
//        }

//        [HttpPost("addProduct")]
//        public async Task<ActionResult<Products>> AddAsync(Products product)
//        {
//            return await productService.AddAsync(product);
//        }

//        [HttpGet("deleteProduct")]
//        public async Task<ActionResult<Products>> DeleteAsync(Guid id)
//        {
//            return await productService.DeleteAsync(id);
//        }

//        [HttpGet("getAllProducts")]
//        public async Task<IEnumerable<Products>> GetAllAsync()
//        {
//            return await productService.GetAllAsync();
//        }

//        [HttpGet("getProduct")]
//        public async Task<ActionResult<Products>> GetAsync(Guid id)
//        {
//            return await productService.GetAsync(id);
//        }

//        [HttpPut("updateProduct")]
//        public async Task<ActionResult<Products>> UpdateAsync(Products product)
//        {
//            return await productService.UpdateAsync(product);
//        }
//    }
//}
