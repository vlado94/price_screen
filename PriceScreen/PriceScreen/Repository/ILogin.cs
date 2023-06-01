using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriceScreen.Models;

namespace PriceScreen.Repository
{
    public interface ILogin
    {
        Task<IEnumerable<User>> getuser();
        Task<User> AuthenticateUser(string email, string password);
    }
}
