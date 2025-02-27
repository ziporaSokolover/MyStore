using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService


    {
        IOrderRepository repository;

        public OrderService(IOrderRepository repository)
        {
            this.repository = repository;
        }

        
        public async Task<Order> GetById(int id)
        {
            return await repository.GetById(id);
        }
        
        public async Task<Order> Post(Order order)
        {
            return await repository.Post(order);
        }

    
}
}
