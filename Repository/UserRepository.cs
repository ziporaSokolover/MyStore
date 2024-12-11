using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;


namespace Repositories
{
    public class UserRepository: IUserRepository
    {
        //public static List<User> Users { get; set; }

        ProductContext _ManagerDBcontext;

        public UserRepository(ProductContext context)
        {
            this._ManagerDBcontext = context;
        }

        const string filePath = "M:\\MyShopWithDB\\MyShop\\user.txt";//

       
        public async Task<User> Login(string email, string password)
        {
            User userFind = await _ManagerDBcontext.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
            //if(userFind.Email== email && userFind.Password == password)
            // {
            return userFind;

            //}
            return null;//
        }


        public async Task<User> Post(User user)
        {
            //var res=  await _ManagerDBcontext.Users.AddAsync(user);
            await _ManagerDBcontext.Users.AddAsync(user);
            await _ManagerDBcontext.SaveChangesAsync();
            //return res- the created user with the id
            return user ;
        }

        public async Task<User> Put(int id,  User user)

        {
            user.UserId = id;
            _ManagerDBcontext.Users.Update(user);
            await _ManagerDBcontext.SaveChangesAsync();
            return user;

        }


    }
}
