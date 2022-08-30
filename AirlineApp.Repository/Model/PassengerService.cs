using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineApp.Repository.Model
{
    public partial class PassengerService
    {
        public int PassengerServiceId { get; set; }
        public int AncillaryServiceId { get; set; }
        public int PassengerId { get; set; }

        public virtual AncillaryService AncillaryService { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}
