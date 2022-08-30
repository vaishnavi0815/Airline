using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Services.User
{
    public interface IUserService
    {
        Task<bool> AddStaffRegistrationDetails(Repository.Model.User user);
    }
}
