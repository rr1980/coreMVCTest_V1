using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class LoginService : ILoginService
    {
        private readonly DataContext _context;

        public LoginService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEntity> Auth(string username, string password)
        {
            return await _context.Users.Include(u => u.RoleToUser).ThenInclude(r => r.Role).SingleOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}

