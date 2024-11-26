using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Repositories;
using Zxcvbn;
namespace Services
{
    public class UserService: IUserServices
    {
        IUserRepository repository;

        public UserService(IUserRepository repository)
        {
                this.repository = repository;
        }
        public User Login(string email, string password)
        {
            return repository.Login(email, password);
        }

        public User Post(User user)
        {
            //check password first
            return repository.Post(user);
        }


        public User Put(int id,  User user)

        {
            //check password first
            return repository.Put(id,user);

        }
        public int cheackPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }

    }
}
