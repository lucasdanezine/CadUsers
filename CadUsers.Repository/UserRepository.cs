using CadUsers.Entities.Models;
using CadUsers.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadUsers.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SysCadContext _context;

        public UserRepository(SysCadContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.User.Include(u => u.Contacts).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.UserName == login);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
