using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineApp.Repository.Model
{
    public partial class PassengerMeal
    {
        public int PassengerMealId { get; set; }
        public int MealId { get; set; }
        public int PassengerId { get; set; }

        public virtual Meal Meal { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}
