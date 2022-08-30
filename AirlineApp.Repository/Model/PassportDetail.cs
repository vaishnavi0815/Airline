using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineApp.Repository.Model
{
    public partial class PassportDetail
    {
        public PassportDetail()
        {
            Passengers = new HashSet<Passenger>();
        }

        public int PassportDetailsId { get; set; }
        public string PassportNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
