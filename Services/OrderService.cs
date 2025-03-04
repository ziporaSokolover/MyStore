using Entities;
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

        public OrderService(IOrderRepository repository, IProductRepository productsRepository)
        {
            this.repository = repository;
            _productsRepository = productsRepository;
        }

        
        public async Task<Order> GetById(int id)
        {
            return await repository.GetById(id);
        }
        
        public async Task<Order> Post(Order order)
        {
            Order goodOrder = await CheckSum(order);

            return await repository.Post(order);
        }

        private async Task<Order> CheckSum(Order order)
         
        {
            int sum = 0;
            foreach (var product in order.OrderItems)
            {
                Product goodProduct = await _productsRepository.GetById(product.ProductId);
                sum += goodProduct.Price;
            }
            if (order.OrderSum != sum)
            {

                order.OrderSum = sum;
                //_logger.LogError("הכניס סכום בכוחות עצמו");
            }

            return order;


        }
    }
}
