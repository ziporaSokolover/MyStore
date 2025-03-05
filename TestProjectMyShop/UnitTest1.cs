

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
            var orderItems = new List<OrderItem>() { new() { ProductId = 1 } };
            var order = new Order { OrderSum = 6, OrderItems = orderItems };

            var mockOrderRepository = new Mock<IOrderRepository>();
            var mockProductRepository = new Mock<IProductRepository>();
            var mockLogger = new Mock<ILogger<OrderService>>();
            var products = new List<Product> { new Product { ProductId = 1, Price = 6 } };
                mockProductRepository.Setup(x => x.Get( It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int?[]>(), It.IsAny<string>()))
                                 .ReturnsAsync(products);

            mockOrderRepository.Setup(x => x.Post(It.IsAny<Order>()))
                               .ReturnsAsync(order);

            var orderService = new OrderService(mockOrderRepository.Object, mockProductRepository.Object, mockLogger.Object) ;

            // Act
            var result = await orderService.Post(order);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(order, result);
        }
        [Fact]
        public async void CheckOrderSum_ValidCredentialsReturnOrder()
        {
            var products = new List<Product>
        {
            new Product { ProductId = 1, Price = 450},
            new Product { ProductId = 2, Price = 500}
        };

            var orders = new List<Order>
        {
            new Order
            {
                UserId = 1,
                OrderSum = 950,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 1, Quentity = 1 },
                    new OrderItem { ProductId = 2, Quentity = 1 }
                }
            }
        };
            var mockContext = new Mock<ProductContext>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders);
            mockContext.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
            var productRepository = new ProductRepository(mockContext.Object);
            var orderRepository = new OrderRepository(mockContext.Object);
            var mockLogger = new Mock<ILogger<OrderService>>();
            var orderService = new OrderService(orderRepository, productRepository, mockLogger.Object);

            var result = await orderService.Post(orders[0]);
            Assert.Equal(result, orders[0]);
        }
        [Fact]
        public async Task UpdateUser_ExistingUser_UpdatesUser()
        {
            var user = new User { UserId = 1, FirstName = "hh", LastName = "hgh                                               " };
            var mockContext = new Mock<ProductContext>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(new List<User>() { user });
            mockContext.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
            mockContext.Setup(x => x.Users.FindAsync(20)).ReturnsAsync(user);

            var userRepository = new UserRepository(mockContext.Object, new LoggerFactory().CreateLogger<UserRepository>());
            var updatedUser = new User { FirstName = "updatedUser", LastName = "user" };

            user = await userRepository.Put(1, updatedUser);

            Assert.Equal("updatedUser", user.FirstName);
            Assert.Equal("user", user.LastName);
            mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once);
        }
    }
}