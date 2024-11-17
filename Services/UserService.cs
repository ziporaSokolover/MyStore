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
            if (cheackPassword(user.Password) > 2) { 
                //return userRepository.AddUser(user);
                 return repository.Post(user);}
            else
            {
                return null;
            }
        }


        public User Put(int id,  User user)

        {
            if (cheackPassword(user.Password) > 2)
            {
                return repository.Put(id, user);
            }
            else
            {
                return null;
            }

        }
        public int cheackPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }

    }
}
