using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
    public class ProductList : IProductList
    {
        private readonly List<Product> products = new List<Product>()
        {
            new Product {ID = Guid.NewGuid(), Name = "Test Product", Description = "Test product description.", Price = 9.99, CreationDate = DateTimeOffset.UtcNow},
            new Product {ID = Guid.NewGuid(), Name = "Test Product 1", Description = "Test product 1 description.", Price = 99.99, CreationDate = DateTimeOffset.UtcNow},
            new Product {ID = Guid.NewGuid(), Name = "Test Product 2", Description = "Test product 2 description.", Price = 999.99, CreationDate = DateTimeOffset.UtcNow}
        };
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
        public Product GetProduct(Guid ID)
        {
            return products.SingleOrDefault(product => product.ID == ID);
        }

        public void CreateProduct(Product product)
        {
            products.Add(product);
        }

        public void EditProduct(Product product)
        {
            var index = products.FindIndex(existingProduct => existingProduct.ID == product.ID);
            products[index] = product;
        }

        public void DeleteProduct(Guid id)
        {
            var index = products.FindIndex(existingProduct => existingProduct.ID == id);
            products.RemoveAt(index);
        }
    }
}
