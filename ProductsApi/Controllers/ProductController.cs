using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private List<ProductModel> _products = new List<ProductModel>() {
            new ProductModel{ProductId =1, ProductName ="Product 1" },            
            new ProductModel{ProductId =2, ProductName ="Product 2" },            
            new ProductModel{ProductId =3, ProductName ="Product 3" },            
            new ProductModel{ProductId =4, ProductName ="Product 4" },            

        };
        [Route("GetProducts")]
        public IActionResult GetProducts() {
            return Ok(_products);
        }
        [Route("GetProductById")]
        public IActionResult GetProductById([FromQuery]int productId) {
            if (productId < 1 && productId >4)
            {
                return BadRequest("Product not found");
            }
            var product = _products.FirstOrDefault(p => p.ProductId == productId);
            return Ok(product);
        }
        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct([FromBody]ProductModel model)
        {
            _products.Add(model);
            return Ok(_products);
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct([FromQuery]int productId, [FromBody]ProductModel model)
        {
            if (productId < 1 || productId > 4)
            {
                return BadRequest("Product not found");
            }
            var prod = _products.FirstOrDefault(p => p.ProductId == productId);            
            prod.ProductName = model.ProductName;            
            return Ok(_products);
        }
    }
}