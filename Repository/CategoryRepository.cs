using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository

    {
        ProductContext _ManagerDBcontext;

        public CategoryRepository(ProductContext context)
        {
            _ManagerDBcontext = context;
        }




        public async Task<List<Category>> Get()
        {
            return await _ManagerDBcontext.Categories.ToListAsync();
        }



    }
}


//using Entities;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Repositories
//{
//    public class CategoryRepository : ICategoryRepository
//    {
//        private readonly IDbContextFactory<ProductContext> _contextFactory;

//        public CategoryRepository(IDbContextFactory<ProductContext> contextFactory)
//        {
//            _contextFactory = contextFactory;
//        }

//        public async Task<List<Category>> Get()
//        {
//            using (var context = _contextFactory.CreateDbContext())
//            {
//                return await context.Categories.ToListAsync();
//            }
//        }
//    }
//}