using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductApplication.Models;
using ProductApplication.Services;

namespace ProductApplication.src.controlers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
        
            
            return Ok(product);
        }
        
        [HttpGet("ordered-by-price")]
        public IActionResult GetProductsOrderedByPrice([FromQuery] bool ascending = true)
        {
            var products = _productService.GetProductsOrderedByPrice(ascending);
            return Ok(products);
        }
        
        [HttpGet("price:decimal")]
        public IActionResult GetProductByPrice( decimal price)
        {
            var products = _productService.GetProductByPrice(price);
            return Ok(products);
        }
    }
}