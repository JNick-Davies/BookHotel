using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Models
{
    class ReservationDetail
    {
  
        public int ReservationId { get; set; }
    
        public Guid StaffIdLogin { get; set; }

       
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        [MaxLength(10, ErrorMessage = "There are too many characters in this field.")]
        public int ConfirmationNumber { get; set; }//range and min max length 

     
        [MinLength(5, ErrorMessage = "Inn Codes are at least 5 characters long.")]
        [MaxLength(6, ErrorMessage = "Inn Codes cannot exceed 6 characters.")]
        public string InnCode { get; set; }//***FK***

     
        [DisplayFormat(DataFormatString = "{0:C}")] //set currency $$ 
        [Range(99, 1999, ErrorMessage = "Currently we only offer rooms between $99 and $1,999")]
        public decimal Rate { get; set; } //range and min max length 

      
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime ArrivalDate { get; set; }

     
        public int NumberOfNights { get; set; }

        public int NumberOfRooms { get; set; } //set to enum? => ***FK***

    
        public string GuestFirstName { get; set; }

        
        public string GuestlastName { get; set; }

       
        public string GuestEmail { get; set; }
    }
}
