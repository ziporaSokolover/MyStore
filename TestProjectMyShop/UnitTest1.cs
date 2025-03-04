

using Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using MyShop.Controllers;
using Repositories;
using Services;


namespace TestProject
{
    public class UnitTest1
    {
        [Fact]

        public async Task LogIn_ValidCredentials_ReturnsUser()
        {
            var user = new User { Email = "hhh@ggg", Password = "gfhjmhjfyhj65" };
            var mocContext = new Mock<ProductContext>();
            var users = new List<User>() { user };
            mocContext.Setup(x => x.Users).ReturnsDbSet(users);
            var mockLogger = new Mock<ILogger<UserRepository>>();
            var userRepository = new UserRepository(mocContext.Object, mockLogger.Object);

            var result = await userRepository.Login(user.Email, user.Password);

            Assert.Equal(user, result);

        }
        [Fact]
        public async Task LogIn_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            var mocContext = new Mock<ProductContext>();
            var users = new List<User>();
            mocContext.Setup(x => x.Users).ReturnsDbSet(users);
            var mockLogger = new Mock<ILogger<UserRepository>>();
            var userRepository = new UserRepository(mocContext.Object, mockLogger.Object);

            // Act
            var result = await userRepository.Login("wrongPassword", "nonExistentUser");
            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task LogIn_WrongPassword_ReturnsNull()
        {
            // Arrange
            var user = new User { Email = "hhh@ggg", Password = "gfhjmhjfyhj65" };
            var mocContext = new Mock<ProductContext>();
            var users = new List<User> { user };
            mocContext.Setup(x => x.Users).ReturnsDbSet(users);
            var mockLogger = new Mock<ILogger<UserRepository>>();
            var userRepository = new UserRepository(mocContext.Object, mockLogger.Object);

            // Act
            var result = await userRepository.Login("wrongPassword", user.Password);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task CreateOrder_checkOrderSum_ReturnsOrder()
        {

            // Arrange
            var orderItems = new List<OrderItem>() { new() { ProductId = 18 } };
            var order = new Order { UserId = 1, OrderSum = 6, OrderItems = orderItems };

            var mockOrderRepository = new Mock<IOrderRepository>();
            var mockProductRepository = new Mock<IProductRepository>();

            var products = new List<Product> { new Product { ProductId = 18, Price = 450 } };

            mockProductRepository.Setup(x => x.Get( It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<int?[]>(), It.IsAny<string>()))
                                 .ReturnsAsync(products);

            mockOrderRepository.Setup(x => x.Post(It.IsAny<Order>()))
                               .ReturnsAsync(order);
            var mockLogger = new Mock<ILogger<OrderService>>();
            var orderService = new OrderService(mockOrderRepository.Object, mockProductRepository.Object, mockLogger.Object);

            // Act
            var result = await orderService.Post(order);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(order, result);
        }
        [Fact]
        public async Task CreateOrder_checkOrderSum_ReturnsNull()
        {
            // Arrange
            var orderItems = new List<OrderItem>() { new() { ProductId = 1 } };
            var order = new Order { OrderSum = 3, OrderItems = orderItems };

            var mockOrderRepository = new Mock<IOrderRepository>();
            var mockProductRepository = new Mock<IProductRepository>();
            var mockIlogger = new Mock<ILogger<OrderService>>();


            var products = new List<Product> { new Product { ProductId = 1, Price = 6 } };
            mockProductRepository.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<int?[]>(), It.IsAny<string>()))
                                 .ReturnsAsync(products);

            mockOrderRepository.Setup(x => x.Post(It.IsAny<Order>()))
                               .ReturnsAsync(order);

            var orderService = new OrderService(mockOrderRepository.Object, mockProductRepository.Object, mockIlogger.Object);

            // Act
            var result = await orderService.Post(order);

            // Assert
            Assert.Null(result);
        }
    }
}