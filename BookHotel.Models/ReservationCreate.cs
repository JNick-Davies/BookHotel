using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Models
{
    public class ReservationCreate
    {
        [Key]
        public int ReservationId { get; set; }
        [Required]
        public Guid StaffIdLogin { get; set; }

        [Required]
        [Range(5,10, ErrorMessage = "There are too many characters in this field.")]
        public int ConfirmationNumber { get; set; }//range and min max length 

        [Required]
        [MinLength(5, ErrorMessage = "Inn Codes are at least 5 characters long.")]
        [MaxLength(6, ErrorMessage = "Inn Codes cannot exceed 6 characters.")]
        public string InnCode { get; set; }//***FK***

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")] //set currency $$ 
        [Range(99, 1999, ErrorMessage = "Currently we only offer rooms between $99 and $1,999")]
        public decimal Rate { get; set; } //range and min max length 

        //public Guid BookingUserId { get; set; } //user booking rooms

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime ArrivalDate { get; set; }

        [Required]
        [Range(0,13, ErrorMessage = "For stays 14 nights or longer please contact the hotel sale's team directly for a long term stay rate.")]
        public int NumberOfNights { get; set; }

        [Required]
        [Range(0, 9, ErrorMessage = "For reservations of 10 rooms or more please contact the hotel sale's team directly for a group room block.")]
        public int NumberOfRooms { get; set; } //set to enum? => ***FK***

        [Required]
        public string GuestFirstName { get; set; }

        [Required]
        public string GuestlastName { get; set; }

        [Required]
        public string GuestEmail { get; set; }
    }
}
