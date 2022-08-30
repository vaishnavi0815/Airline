using AirlineApp.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Repository.AirlineStaff
{
    public class AirlineStaffData : IAirlineStaffData
    {
        private readonly airlinedbContext _airlineContext;

        public AirlineStaffData(airlinedbContext airlineContext)
        {
            _airlineContext = airlineContext;
        }
        public async Task<List<Passenger>> GetPassengers()
        {
            try
            {
                return await _airlineContext.Passengers.Include(flight=>flight.Flight).Include(passportDetails => passportDetails.PassportDetails).Include(passengerService => passengerService.PassengerServices).ThenInclude(service=>service.AncillaryService)
                            .Include(meals => meals.PassengerMeals).Include(shopRequests => shopRequests.PassengerShopRequests).Include(status => status.Status).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
