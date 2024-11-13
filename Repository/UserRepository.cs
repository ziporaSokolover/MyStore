using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;


namespace Repositories
{
    public class UserRepository: IUserRepository
    {
        public static List<User> Users { get; set; }
        //public UserRepository()
        //{

        //}

        const string filePath = "M:\\MyShop\\MyShop\\user.txt";
        

        public User Login(string email, string password)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User userFind = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (userFind.Email == email && userFind.Password == password)
                        return userFind;
                }
            }
            return null;
        }
        public User Post( User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
        }

        public User Put(int id,  User user)

        {
            user.UserId = id;
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User putUser = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(user));
                System.IO.File.WriteAllText(filePath, text);
                return user;
            }
            return null;
        }

        
    }
}
