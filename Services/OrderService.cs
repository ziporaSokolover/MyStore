using Entities;
using Microsoft.Extensions.Logging;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Services
{
    public class OrderService : IOrderService


    {
        IOrderRepository repository;
        IProductRepository _productsRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository repository, IProductRepository productsRepository, ILogger<OrderService> logger)
        {
            this.repository = repository;
            _productsRepository = productsRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        
        public async Task<Order> GetById(int id)
        {
            return await repository.GetById(id);
        }
        
        public async Task<Order> Post(Order order)
        {
            Order goodOrder = await CheckSum(order);

            return await repository.Post(goodOrder);
        }

        private async Task<Order> CheckSum(Order order)
         
        {
            int sum = 0;
            foreach (var product in order.OrderItems)
            {
                Product goodProduct = await _productsRepository.GetById(product.ProductId);
                if (goodProduct == null) // בדיקה אם המוצר לא נמצא
                {
                    _logger.LogError($"Product with ID {product.ProductId} not found");
                    throw new Exception($"Product with ID {product.ProductId} not found");
                }
                sum += goodProduct.Price;
            }
            if (order.OrderSum != sum)
            {

                order.OrderSum = sum;
                _logger.LogError("הכניס סכום בכוחות עצמו");
                          }

            return order;


        }
    }
}
