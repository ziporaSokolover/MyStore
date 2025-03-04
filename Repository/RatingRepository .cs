using AutoMapper;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {
        ProductContext manageDbContext;
        private readonly ILogger<UserRepository> _logger;

        public RatingRepository(IMapper mapper, ProductContext manageDbContext, ILogger<UserRepository> logger)
        {
            this.manageDbContext = manageDbContext;
            _logger = logger;
        }
        public async Task<Rating> AddRating(Rating rating)
        {
            await manageDbContext.Ratings.AddAsync(rating);
            await manageDbContext.SaveChangesAsync();
           return rating;
            
        }

    }
}
