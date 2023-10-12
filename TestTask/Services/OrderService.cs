using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class OrderService:IOrderService
    {
        public OrderService(ApplicationDbContext context)
        {
            Context = context;
        }
        private ApplicationDbContext Context { get; }

        public Task<Order> GetOrder()
        {
            return Context.Orders
                 .OrderByDescending(order => order.Quantity* order.Price)
                 .FirstOrDefaultAsync();
        }

        public Task<List<Order>> GetOrders()
        {
            return Context.Orders
                .Where(order => order.Quantity>10)
                .ToListAsync();
        }
    }
}
