using AirlineApp.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Services.AirlineStaff
{
    public interface IAirlineStaffService
    {
        Task<List<Passenger>> GetPassengers();
    }
}
