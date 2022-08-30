using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineApp.Repository.Model
{
    public partial class Meal
    {
        public Meal()
        {
            PassengerMeals = new HashSet<PassengerMeal>();
        }

        public int MealId { get; set; }
        public string MealTancillaryservicesancillaryservicesype { get; set; }

        public virtual ICollection<PassengerMeal> PassengerMeals { get; set; }
    }
}
