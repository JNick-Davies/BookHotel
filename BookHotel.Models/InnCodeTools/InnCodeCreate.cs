using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Models.InnCode
{
    public class InnCodeCreate
    {
        [Key]
        [Required]
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        [MaxLength(6, ErrorMessage = "There are too many characters in this field.")]
        public string HotelInnCode { get; set; }

        [Required]
        [Display(Name = "Hotel Name")]
        public string HotelName { get; set; }

        [Required]
        [Display(Name = "Hotel Address")]
        public string HotelAddress { get; set; }

        [Required]
        [Display(Name = "Hotel Phone Number")]
        [MinLength(7, ErrorMessage = "Please enter at least 7 numbers.")]
        [MaxLength(12, ErrorMessage = "There are too many characters in this field.")]
        public int HotelPhoneNumber { get; set; }

        [Display(Name = "Hotel offers Spa service")]
        public bool HasSpa { get; set; }

        [Display(Name = "Hotel offers golf service")]
        public bool HasGolfCourse { get; set; }

        [Display(Name = "Hotel has a roof top bar ")]
        public bool HasRooftopBar { get; set; }

        [Display(Name = "Number of stars")]
        [Range(1, 5, ErrorMessage = "Please enter a star rating between 1 and 5.")]
        public int NumberOfStars { get; set; }
    }
}
