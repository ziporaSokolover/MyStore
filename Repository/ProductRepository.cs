using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository: IProductRepository
    {
        ProductContext _ManagerDBcontext;

        public ProductRepository(ProductContext context)
        {
            this._ManagerDBcontext = context;
        }




        //public async Task<List<Product>> Get()
        //{
        //    return await _ManagerDBcontext.Products.ToListAsync();
        //}
        public async Task<List<Product>> Get(int? minPrice, int? maxPrice, int?[] categoryIds, string? desc)
        {

            var query = _ManagerDBcontext.Products.Where(Product =>
            (desc == null ? (true) : (Product.ProductName.Contains(desc)))
             && (minPrice == null ? (true) : (Product.Price >= minPrice))
             && ((maxPrice == null) ? (true) : (Product.Price <= maxPrice))
             && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(Product.CategoryId))))
                 

                             
            .OrderBy(Product => Product.Price).Include(p => p.Category);
            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
            return products;

        }



    }

}
