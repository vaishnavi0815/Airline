using AirlineApp.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Repository.User
{
    public class UserData : IUserData
    {
        private readonly airlinedbContext _airlineContext;

        public UserData(airlinedbContext airlineContext)
        {
            _airlineContext = airlineContext;
        }

        public async Task<bool> AddStaffRegistrationDetails(Model.User user)
        {
            int isUserSaved;
            try
            {
                Model.User userFound = await _airlineContext.Users.FirstOrDefaultAsync(userData => userData.EmailId == user.EmailId);
                if (userFound == null)
                {
                    await _airlineContext.AddAsync(user);
                    isUserSaved = await _airlineContext.SaveChangesAsync();
                    if (isUserSaved > 0)
                        return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<Model.User> GetUsersByEmail(Model.User user)
        {
            Model.User userFound = await _airlineContext.Users.FirstOrDefaultAsync(userData => userData.EmailId == user.EmailId);
            return userFound;
        }
    }
}
