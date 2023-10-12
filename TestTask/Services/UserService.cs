using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class UserService:IUserService
    {
        public UserService(ApplicationDbContext context)
        {
            Context = context;
        }
        private ApplicationDbContext Context { get; }
        public Task<User> GetUser()
        {

            return Context.Users
                .OrderByDescending(user => user.Orders.Count())
                .FirstOrDefaultAsync();
        }

        public Task<List<User>> GetUsers()
        {
            return Context.Users
                .Where(user=>user.Status == Enums.UserStatus.Inactive)
                .ToListAsync();
        }

       
    }
}
