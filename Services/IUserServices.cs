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

         User Login(string email, string password);



         User Post(User user);



         User Put(int id, User user);


         int cheackPassword(string password);
       

    }
}

    

