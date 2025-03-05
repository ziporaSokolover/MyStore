using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectMyShop
{
    public class UserReposetoryIntegrationTests : IClassFixture<DatabaseFixure>
    {
        private readonly ProductContext _context;
        private readonly UserRepository _reposetory;

        public UserReposetoryIntegrationTests(DatabaseFixure fixture)
        {
            _context = fixture.Context;
            var mockLogger = new Mock<ILogger<UserRepository>>();
            _reposetory = new UserRepository(_context, mockLogger.Object);
        }
        [Fact]
        public async Task Get_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var user = new User { Email = "hujjEEHTYU123456434", Password = "FXHTZDV" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            // Act
            var retrievedUser = await _reposetory.Login(user.Email, user.Password);
            // var retrievedUser = await _context.Users.FindAsync(user.Id);
            // Assert
            Assert.NotNull(retrievedUser);
            Assert.Equal(user.Email, retrievedUser.Email);
        }

        [Fact]
        public async Task LogIn_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            //var userRepository = new UserRepository(_context);

            // Act
            var result = await _reposetory.Login("wrongPassword", "nonExistentUser");

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task LogIn_WrongPassword_ReturnsNull()
        {
            // Arrange
            var user = new User { Email = "hhh@ggg", Password = "gfhjmhjfyhj65" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            // Act
            var result = await _reposetory.Login("wrongPassword", user.Email);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task Post_ShouldAddUser_WhenUserIsValid()
        {
            // Arrange
            var user = new User { Email = "newuser@example.com", Password = "securepassword", FirstName = "aa", LastName = "bb" };

            // Act
            // var addedUser = await _context.Users.AddAsync(user);
            var addedUser = await _reposetory.Post(user);


            //await _context.SaveChangesAsync();

            // Assert
            Assert.NotNull(addedUser);
            Assert.Equal(user.Email, addedUser.Email);
            Assert.True(addedUser.UserId > 0); // נניח שהמזהה יוקצה אוטומטית
        }


    }





}