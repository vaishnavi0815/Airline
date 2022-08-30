using AirlineApp.Repository.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserData _userData;

        public UserService(IUserData userData)
        {
            _userData = userData;
        }
        public async Task<bool> AddStaffRegistrationDetails(Repository.Model.User user)
        {
            return await _userData.AddStaffRegistrationDetails(user);
        }
    }
}
