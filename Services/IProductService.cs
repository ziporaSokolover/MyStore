﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product>> Get(int? minPrice, int? maxPrice, int?[] categoryIds, string? desc);
       


    }
}
