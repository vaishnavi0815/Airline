using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AirlineApp.Repository.Model
{
    public partial class User
    {
        public User()
        {
            Passengers = new HashSet<Passenger>();
        }

        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string UserPassword { get; set; }
        public int RoleId { get; set; }

        [NotMapped]
        public string AuthToken { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
