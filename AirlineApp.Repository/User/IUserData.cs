using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Repository.User
{
    public interface IUserData
    {
        Task<Model.User> GetUsersByEmail(Model.User user);
        Task<bool> AddStaffRegistrationDetails(Model.User user);
    }
}
