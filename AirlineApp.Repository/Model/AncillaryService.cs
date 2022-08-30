using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineApp.Repository.Model
{
    public partial class AncillaryService
    {
        public AncillaryService()
        {
            PassengerServices = new HashSet<PassengerService>();
        }

        public int AncillaryServiceId { get; set; }
        public string ServiceName { get; set; }

        public virtual ICollection<PassengerService> PassengerServices { get; set; }
    }
}
