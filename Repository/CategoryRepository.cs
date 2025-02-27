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
        this._ManagerDBcontext = context;
    }




    public async Task<List<Category>> Get()
    {
        return await _ManagerDBcontext.Categories.ToListAsync();
    }


    
}
}
