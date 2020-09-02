using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Data
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        [Required]
        public int ConfirmationNumber { get; set; }//range and min max length 
        [ForeignKey(nameof(HotelInnCode))]
        public string InnCode { get; set; }//***FK***
        public virtual InnCode HotelInnCode { get; set; }
        public decimal Rate { get; set; } //range and min max length 
        //public Guid BookingUserId { get; set; } //user booking rooms
        public DateTime ArrivialDate { get; set; }
        public int NumberOfNights { get; set; }
        public int NumberOfRooms { get; set; } //set to enum? => ***FK***
        
        [ForeignKey(nameof(ApplicationLoginUser))]
        public Guid StaffIdLogin { get; set; } //FK to ApplicationUser =>Staff class 
        public virtual ApplicationLoginUser ApplicationLoginUser { get; set; }
        public string GuestFirstName { get; set; }
        public string GuestlastName { get; set; }
        public string GuestEmail { get; set; }

    }
}
