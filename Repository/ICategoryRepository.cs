﻿//using Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repositories
//{
//    public interface ICategoryRepository
//    {
//        Task<List<Category>> Get();

//    }
//}

using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> Get();
    }
}