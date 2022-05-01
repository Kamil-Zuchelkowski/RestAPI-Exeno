using System;
using System.Collections.Generic;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
    public interface IProductList
    {
        Product GetProduct(Guid ID);
        IEnumerable<Product> GetProducts();
        void CreateProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(Guid id);
    }
}