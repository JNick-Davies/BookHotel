using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Models
{
    public class ReservationEdit
    {
        public int ReservationId { get; set; }
        public decimal Rate { get; set; } //range and min max length 
        //public Guid BookingUserId { get; set; } //user booking rooms
        public DateTime ArrivialDate { get; set; }
        public int NumberOfNights { get; set; }
        public int NumberOfRooms { get; set; } //set to enum? => ***FK***
        public string GuestFirstName { get; set; }
        public string GuestlastName { get; set; }
        public string GuestEmail { get; set; }
    }
}
