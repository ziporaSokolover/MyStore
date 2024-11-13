using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    internal interface IUserRepository
    {
         User Login(string email, string password);
         User Post(User user);
         User Put(int id, User user);

    }
}
