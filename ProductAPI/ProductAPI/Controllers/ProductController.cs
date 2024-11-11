using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.DAL;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }
        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(product);
                return Ok("Product Added Successfully");
            }
            else return BadRequest("Failed To Add The Product");
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var response = _productService.UpdateProduct(product);
                if (response == 1)
                    return Ok("Updated The Product Successfully");
                else return NotFound("Failed To Update The Product");
            }
            return BadRequest("Check The Input");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {

            var response = _productService.DeleteProduct(id);
            if (response == 1)
            {
                return Ok("Product Deleted Successfully");
            }
            else return NotFound("Failed To Delete The Product");

        }
        [HttpGet]
        public List<ProductDto> GetAllPRoductsWithOutId()
        {
            return _productService.GetAllPRoductsWithOutId();
        }


    }
}
