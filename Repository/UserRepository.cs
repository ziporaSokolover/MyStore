using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;

using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Internal;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        //public static List<User> Users { get; set; }

        ProductContext _ManagerDBcontext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ProductContext context, ILogger<UserRepository> logger)
        {
            this._ManagerDBcontext = context;
            this._logger = logger;
        }

        const string filePath = "M:\\MyShopWithDB\\MyShop\\user.txt";


        public async Task<User> Login(string email, string password)
        {
            User userFind = await _ManagerDBcontext.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
            if (userFind != null)
                _logger.LogCritical($"login attempted with User Name:{userFind.FirstName},Email:{email}");
            return userFind;

        }
        public async Task<User> Post(User user)
        {
            await _ManagerDBcontext.Users.AddAsync(user);
            await _ManagerDBcontext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Put(int id, User user)

        {
            user.UserId = id;
            _ManagerDBcontext.Users.Update(user);
            await _ManagerDBcontext.SaveChangesAsync();
            return user;

        }

        public async Task<User> GetUserByEmail(string email)
        {
            User userFind = await _ManagerDBcontext.Users.FirstOrDefaultAsync(u => u.Email == email);

            return userFind;


        }












    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Entities;
//using Microsoft.Extensions.Logging;

//namespace Repositories
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly IDbContextFactory<ProductContext> _contextFactory;
//        private readonly ILogger<UserRepository> _logger;

//        public UserRepository(IDbContextFactory<ProductContext> contextFactory, ILogger<UserRepository> logger)
//        {
//            _contextFactory = contextFactory;
//            _logger = logger;
//        }

//        const string filePath = "M:\\MyShopWithDB\\MyShop\\user.txt";

//        public async Task<User> Login(string email, string password)
//        {
//            using (var context = _contextFactory.CreateDbContext())
//            {
//                User userFind = await context.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
//                if (userFind != null)
//                    _logger.LogCritical($"login attempted with User Name:{userFind.FirstName},Email:{email}");
//                return userFind;
//            }
//        }

//        public async Task<User> Post(User user)
//        {
//            using (var context = _contextFactory.CreateDbContext())
//            {
//                await context.Users.AddAsync(user);
//                await context.SaveChangesAsync();
//                return user;
//            }
//        }

//        public async Task<User> Put(int id, User user)
//        {
//            using (var context = _contextFactory.CreateDbContext())
//            {
//                user.UserId = id;
//                context.Users.Update(user);
//                await context.SaveChangesAsync();
//                return user;
//            }
//        }

//        public async Task<User> GetUserByEmail(string email)
//        {
//            using (var context = _contextFactory.CreateDbContext())
//            {
//                User userFind = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
//                return userFind;
//            }
//        }
//    }
//}