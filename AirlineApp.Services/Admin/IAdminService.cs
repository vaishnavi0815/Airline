using AirlineApp.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Services.Admin
{
    public interface IAdminService
    {
        Task<bool> AddPassenger(Passenger passenger);
        Task<bool> UpdatePassenger(Passenger passenger);
        Task<bool> DeleteAndUpdateServices(Passenger passenger);
    }
}
