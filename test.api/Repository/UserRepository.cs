using System;
using test.api.Context;
using test.api.Models;
using Microsoft.EntityFrameworkCore;

namespace test.api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyContext _context;

        public UserRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAndPassword(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }

}
