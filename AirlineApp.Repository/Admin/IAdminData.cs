using AirlineApp.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Repository.Admin
{
    public interface IAdminData
    {
        Task<bool> AddPassenger(Passenger passenger);
        Task<bool> UpdatePassenger(Passenger passenger);
        Task<bool> DeleteAndUpdateServices(Passenger passenger);
    }
}
