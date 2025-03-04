

using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ICategoryService
    {
        Task<List<Category>> Get();
    }
}
