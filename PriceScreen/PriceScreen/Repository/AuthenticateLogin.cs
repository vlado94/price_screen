using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PriceScreen.Models;

namespace PriceScreen.Repository
{
    public class AuthenticateLogin : ILogin
    {
        private readonly DatabaseContext _context;
        public AuthenticateLogin(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<User> AuthenticateUser(string email, string password)
        {
            var succeeded = await _context.User.FirstOrDefaultAsync
                (authUser => authUser.Email == email && authUser.Password == password);
            return succeeded;
        }
        public async Task<IEnumerable<User>> getuser()
        {
            return await _context.User.ToListAsync();
        }
        
    }
}
