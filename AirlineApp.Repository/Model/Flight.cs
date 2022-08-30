using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineApp.Repository.Model
{
    public partial class Flight
    {
        public Flight()
        {
            Passengers = new HashSet<Passenger>();
        }

        public int FlightId { get; set; }
        public string FlightName { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
