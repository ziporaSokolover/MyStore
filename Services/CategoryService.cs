


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