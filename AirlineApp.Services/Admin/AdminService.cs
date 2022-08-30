using AirlineApp.Repository.Admin;
using AirlineApp.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IAdminData _adminData;

        public AdminService(IAdminData adminData)
        {
            _adminData = adminData;
        }
        public async Task<bool> AddPassenger(Passenger passenger)
        {
            return await _adminData.AddPassenger(passenger);
        }

        public async Task<bool> DeleteAndUpdateServices(Passenger passenger)
        {
            return await _adminData.DeleteAndUpdateServices(passenger);
        }

        public async Task<bool> UpdatePassenger(Passenger passenger)
        {
            return await _adminData.UpdatePassenger(passenger);
        }
    }
}
