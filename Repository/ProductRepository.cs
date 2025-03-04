using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductContext _ManagerDBcontext;

        public ProductRepository(ProductContext context)
        {
            this._ManagerDBcontext = context;
        }
        public async Task<Product> GetById(int id)
        {
            return await _ManagerDBcontext.Products.FindAsync(id);

        }

        //var query = _ManagerDBcontext.Products.Where(Product =>
        //  (desc == null ? true : Product.ProductName.Contains(desc))
        //  && (minPrice == null ? true : Product.Price >= minPrice)
        //  && (maxPrice == null ? true : Product.Price <= maxPrice)
        //  && (categoryIds == null || categoryIds.Length == 0 ? true : categoryIds.Contains(Product.CategoryId)))
        //  .OrderBy(Product => Product.Price)
        //  .Include(p => p.Category);

        //Console.WriteLine(query.ToQueryString());
        //List<Product> products = await query.ToListAsync();
        //return products;

        public async Task<List<Product>> Get(int? minPrice, int? maxPrice, int?[] categoryIds, string? desc)
        {

            var query = _ManagerDBcontext.Products.Where(Product =>
             (desc == null ? true : Product.ProductName.Contains(desc))
            && (minPrice == null ? true : Product.Price >= minPrice)
            && (maxPrice == null ? true : Product.Price <= maxPrice)
            && (categoryIds == null || categoryIds.Length == 0 ? true : categoryIds.Contains(Product.CategoryId))) // <--- שורה מתוקנת
            .OrderBy(Product => Product.Price).Include(p => p.Category);
            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
            return products;

        }



    }

}



//using Entities;

//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Repositories
//{
//    public class ProductRepository : IProductRepository
//    {
//        private readonly IDbContextFactory<ProductContext> _contextFactory;

//        public ProductRepository(IDbContextFactory<ProductContext> contextFactory)
//        {
//            _contextFactory = contextFactory;
//        }

//        public async Task<Product> GetById(int id)
//        {
//            using (var context = _contextFactory.CreateDbContext())
//            {
//                return await context.Products.FindAsync(id);
//            }
//        }

//        public async Task<List<Product>> Get(int? minPrice, int? maxPrice, int?[] categoryIds, string? desc)
//        {
//            using (var context = _contextFactory.CreateDbContext())
//            {
//                var query = context.Products.Where(Product =>
//                    (desc == null ? true : Product.ProductName.Contains(desc))
//                    && (minPrice == null ? true : Product.Price >= minPrice)
//                    && (maxPrice == null ? true : Product.Price <= maxPrice)
//                    && (categoryIds == null || categoryIds.Length == 0 ? true : categoryIds.Contains(Product.CategoryId)))
//                    .OrderBy(Product => Product.Price)
//                    .Include(p => p.Category);

//                Console.WriteLine(query.ToQueryString());
//                List<Product> products = await query.ToListAsync();
//                return products;
//            }
//        }
//    }
//}
