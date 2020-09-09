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
        [Display(Name = "Confirmation Number")]
        public int ConfirmationNumber { get; set; }//range and min max length 
        [ForeignKey(nameof(HotelInnCode))]
        [Display(Name = "Hotel Inn Code")]

        public string InnCode { get; set; }//***FK***
        [Display(Name = "Hotel Inn Code")]
        public virtual InnCode HotelInnCode { get; set; }
        public decimal Rate { get; set; } //range and min max length 
                                          //public Guid BookingUserId { get; set; } //user booking rooms
        [Display(Name = "Arrival")]
        public DateTime ArrivialDate { get; set; }

        [Display(Name = "Number of nights")]
        public int NumberOfNights { get; set; }
        [Display(Name = "Number of rooms")]
        public int NumberOfRooms { get; set; } //set to enum? => ***FK***

        [ForeignKey(nameof(ApplicationLoginUser))]
        public Guid StaffIdLogin { get; set; } //FK to ApplicationUser =>Staff class 
        public virtual ApplicationLoginUser ApplicationLoginUser { get; set; }
        [Display(Name = "Guest first name")]
        public string GuestFirstName { get; set; }
        [Display(Name = "Guest last name")]
        public string GuestlastName { get; set; }
        [Display(Name = "Guest email")]
        public string GuestEmail { get; set; }
        public virtual ICollection<NumOfRoomsToRoomType> NumOfRoomsToRoomTypes { get; set; } //= new List<NumOfRoomsToRoomTypes>(); 
    }
}
