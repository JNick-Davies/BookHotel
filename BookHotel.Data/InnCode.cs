using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Data
{
    public class InnCode
    {
        [Key]
        [Required]
        [Display(Name = "Hotel Inn Code")]
        public string HotelInnCode { get; set; }
        
        [Required]
        [Display(Name =("Hotel Name"))]
        public string HotelName { get; set; }

        [Required]
        [Display(Name = "Hotel Address")]
        public string HotelAddress { get; set; }

        [Required]
        [Display(Name = "Hotel Phone Number")]
        public int HotelPhoneNumber { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Hotel offers spa service")]
        public bool HasSpa { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Hotel offers golf service")]
        public bool HasGolfCourse { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Hotel has a roof top bar")]
        public bool HasRooftopBar { get; set; }

        [Display(Name = "Number of stars")]
        [Range(1, 5, ErrorMessage = "Please enter a star rating between 1 and 5.")]
        public int NumberOfStars { get; set; }
    }
}
