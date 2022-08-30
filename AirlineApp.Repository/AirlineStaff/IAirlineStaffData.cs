using AirlineApp.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Repository.AirlineStaff
{
    public interface IAirlineStaffData
    {
        Task<List<Passenger>> GetPassengers();
    }
}
