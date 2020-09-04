using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Models.InnCodeTools
{
    public class InnCodeEdit
    {
        [Display(Name = "Hotel Inn Code")]
        public string HotelInnCode { get; set; }

        [Display(Name = "Hotel Name")]
        public string HotelName { get; set; }

        [Display(Name = "Hotel Address")]
        public string HotelAddress { get; set; }

        [Display(Name = "Hotel Phone Number")]
        public int HotelPhoneNumber { get; set; }

        [Display(Name = "Hotel offers Spa service")]
        public bool HasSpa { get; set; }

        [Display(Name = "Hotel offers Golf service")]
        public bool HasGolfCourse { get; set; }

        [Display(Name = "Hotel has roof top bar")]
        public bool HasRooftopBar { get; set; }

        [Display(Name = "Number of stars")]
        public int NumberOfStars { get; set; }
    }
}
