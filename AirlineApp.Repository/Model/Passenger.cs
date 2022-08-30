using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineApp.Repository.Model
{
    public partial class Passenger
    {
        public Passenger()
        {
            PassengerMeals = new HashSet<PassengerMeal>();
            PassengerServices = new HashSet<PassengerService>();
            PassengerShopRequests = new HashSet<PassengerShopRequest>();
        }

        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public string Address { get; set; }
        public int FlightId { get; set; }
        public int? PassportDetailsId { get; set; }
        public int SeatNumber { get; set; }
        public DateTime FlightDateTime { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual PassportDetail PassportDetails { get; set; }
        public virtual PassengerStatus Status { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PassengerMeal> PassengerMeals { get; set; }
        public virtual ICollection<PassengerService> PassengerServices { get; set; }
        public virtual ICollection<PassengerShopRequest> PassengerShopRequests { get; set; }
    }
}
