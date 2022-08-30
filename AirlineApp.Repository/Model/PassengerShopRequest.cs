using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineApp.Repository.Model
{
    public partial class PassengerShopRequest
    {
        public int PassengerRequestId { get; set; }
        public int ShopRequestId { get; set; }
        public int PassengerId { get; set; }

        public virtual Passenger Passenger { get; set; }
        public virtual ShopRequest ShopRequest { get; set; }
    }
}
