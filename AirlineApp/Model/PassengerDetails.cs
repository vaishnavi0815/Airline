using AirlineApp.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineApp.Model
{
    public class PassengerDetails
    {
        public Passenger Passenger { get; set; }
        public PassengerService Passengerservice { get; set; }
        public PassengerMeal Passengermeal { get; set; }
        public PassengerShopRequest Passengershoprequest { get; set; }
    }
}
