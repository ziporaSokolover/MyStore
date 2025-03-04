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
        public async Task<User> Login(string email, string password)
        {
            return await repository.Login(email, password);
        }

        public async Task<User> Post(User user)
        {
            if (cheackPassword(user.Password) > 2) { 
                //return userRepository.AddUser(user);
                 return await repository.Post(user);}
            else
            {
                return null;
            }
        }


        public async Task<User> Put(int id,  User user)

        {
            if (cheackPassword(user.Password) > 2)
            {
                return await repository.Put(id, user);
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


        public async Task<User> GetUserByEmail(string email)
        {
            return await repository.GetUserByEmail(email);
        }
    }
}
