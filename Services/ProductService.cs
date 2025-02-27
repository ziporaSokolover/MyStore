using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }
        

        public async Task<List<Product>> Get(int? minPrice, int? maxPrice, int?[] categoryIds, string? desc)
        {
            return await repository.Get( minPrice,  maxPrice,  categoryIds,  desc);
        }
        
    }
}
