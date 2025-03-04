using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository: IOrderRepository
    { 


        ProductContext _ManagerDBcontext;

        public OrderRepository(ProductContext context)
        {
            this._ManagerDBcontext = context;
        }

        public async Task<Order> GetById(int id)
        {
            return await _ManagerDBcontext.Orders.FirstOrDefaultAsync(o=>o.OrderId==id);
        }

         public async Task<Order> Post(Order newOrder)
        {
            newOrder.OrdetDate = DateTime.Now;
            await _ManagerDBcontext.Orders.AddAsync(newOrder);
            await _ManagerDBcontext.SaveChangesAsync();

            Order order = await _ManagerDBcontext.Orders.Include(currentOrder => currentOrder.User).FirstOrDefaultAsync(currentOrder => currentOrder.OrderId == newOrder.OrderId);
            

            return order;
}



    }
















}

