using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineApp.Repository.Model
{
    public partial class ShopRequest
    {
        public ShopRequest()
        {
            PassengerShopRequests = new HashSet<PassengerShopRequest>();
        }

        public int ShopRequestId { get; set; }
        public string ShopRequestType { get; set; }

        public virtual ICollection<PassengerShopRequest> PassengerShopRequests { get; set; }
    }
}
