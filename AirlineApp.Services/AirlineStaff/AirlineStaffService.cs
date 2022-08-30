using AirlineApp.Repository.AirlineStaff;
using AirlineApp.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Services.AirlineStaff
{
    public class AirlineStaffService : IAirlineStaffService
    {
        private readonly IAirlineStaffData _airlineStaffData;

        public AirlineStaffService(IAirlineStaffData airlineStaffData)
        {
            _airlineStaffData = airlineStaffData;
        }
        public async Task<List<Passenger>> GetPassengers()
        {
            return await _airlineStaffData.GetPassengers();
        }
    }
}
