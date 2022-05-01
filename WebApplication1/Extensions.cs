using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Entities;

namespace WebApplication1
{
    public static class Extensions
    {
        public static ProductDTO ProductToDTO(this Product product)
        {
            return new ProductDTO
            {
                ID = product.ID,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CreationDate = product.CreationDate
            };
        }
    }
}
