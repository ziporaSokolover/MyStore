//using Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Entities;
//using Repositories;

//namespace Services
//{
//    public class CategoryService : ICategoryService

//    {
//        ICategoryRepository repository;

//        public CategoryService(ICategoryRepository repository)
//        {
//            this.repository = repository;
//        }


//        public async Task<List<Category>> Get()
//        {
//            return await repository.Get();
//        }

//    }
//}


using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repositories;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Category>> Get()
        {
            return await repository.Get();
        }
    }
}