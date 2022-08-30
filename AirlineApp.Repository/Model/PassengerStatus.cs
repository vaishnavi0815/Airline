using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineApp.Repository.Model
{
    public partial class PassengerStatus
    {
        public PassengerStatus()
        {
            Passengers = new HashSet<Passenger>();
        }

        public int StatusId { get; set; }
        public bool? CheckedIn { get; set; }
        public bool? RequiringWheelChair { get; set; }
        public bool? PassengerWithInfants { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
