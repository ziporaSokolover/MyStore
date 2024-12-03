using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> Login(string email, string password);
         Task<User> Post(User user);
        Task<User> Put(int id, User user);

    }
}
