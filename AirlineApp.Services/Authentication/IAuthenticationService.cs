using AirlineApp.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApnaAahar.Services
{
    public interface IAuthenticationService
    {
        Task<User> Authenticate(User user);
        //Task<string> AuthenticateVisitor();
    }
}
