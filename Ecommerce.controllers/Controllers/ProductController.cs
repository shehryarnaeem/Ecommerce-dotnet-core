using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.models;
using Ecommerce.services.interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.controllers.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            IEnumerable<Product> products = this._productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            Product product = this._productService.GetById(id);
            return Ok(product);
        }

        [HttpPost("")]
        public ActionResult<Product> PostProduct(Product product)
        {
            Product newProduct = new Product();
            newProduct = product;
            this._productService.Create(newProduct);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product updatedProduct)
        {
            Product product = this._productService.GetById(id);
            product = updatedProduct;
            this._productService.Update(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProductById(int id)
        {
            this._productService.Delete(id);
            return Ok();
        }
    }
}