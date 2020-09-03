using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Models
{
    public class ReservationListItem
    {
        //[Display(Name = "Confirmation number")]
        
        public int ReservationId { get; set; } //do we need this??!?
        [Display(Name = "Confirmation number")]
        public int ConfirmationNumber { get; set; } 
        public string InnCode { get; set; }
        [Display(Name = "Arriving on")]
        public DateTime ArrivialDate { get; set; }
        [Display(Name = "Number of nights")]
        public int NumberOfNights { get; set; }
        public decimal Rate { get; set; }
    }
}
