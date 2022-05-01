using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Entities;
using WebApplication1.Repositories;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductList repository;
        public ProductController(IProductList repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IEnumerable<ProductDTO> GetProducts()
        {
            var Products = repository.GetProducts().Select(product => product.ProductToDTO());
            return Products;
        }
        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProduct(Guid id)
        {
            var Product = repository.GetProduct(id);
            if (Product is null)
                return NotFound();
            return Product.ProductToDTO();
        }
        [HttpPost]
        public ActionResult<ProductDTO> CreateProduct(CreateProductDTO productDTO)
        {
            Product product = new Product
            {
                ID = Guid.NewGuid(),
                Name = productDTO.Name,
                Price = productDTO.Price,
                Description = productDTO.Description,
                CreationDate = DateTimeOffset.UtcNow
            };
            repository.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ID }, product.ProductToDTO());
        }
        [HttpPut("{id}")]
        public ActionResult EditProduct(Guid id, EditProductDTO productDTO)
        {
            var existingProduct = repository.GetProduct(id);
            if(existingProduct is null)
            {
                return NotFound();
            }
            Product EditedProduct = new Product
            {
                ID = existingProduct.ID,
                Name = productDTO.Name,
                Price = productDTO.Price,
                Description = productDTO.Description,
                CreationDate = existingProduct.CreationDate
            };
            repository.EditProduct(EditedProduct);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(Guid id)
        {
            var existingProduct = repository.GetProduct(id);
            if (existingProduct is null)
            {
                return NotFound();
            }
            repository.DeleteProduct(id);
            return NoContent();
        }
    }
}
