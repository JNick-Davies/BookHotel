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
        public string HotelName { get; set; }

        [Required]
        public string HotelAddress { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Please enter at least 10 numbers.")]
        [MaxLength(12, ErrorMessage = "There are too many characters in this field.")]
        public int HotelPhoneNumber { get; set; }

        public bool HasSpa { get; set; }

        public bool HasGolfCourse { get; set; }

        public bool HasRooftopBar { get; set; }

        [Range(1, 5, ErrorMessage = "Please enter a star rating between 1 and 5.")]
        public int NumberOfStars { get; set; }
    }
}
