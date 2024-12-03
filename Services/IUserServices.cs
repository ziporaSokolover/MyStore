using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public interface IUserServices
    {

        Task<User> Login(string email, string password);



         Task <User>  Post(User user);



        Task<User> Put(int id, User user);


         int cheackPassword(string password);
       

    }
}

    

