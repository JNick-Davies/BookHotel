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
        public string HotelInnCode { get; set; }
        
        [Required]
        public string HotelName { get; set; }

        [Required]
        public string HotelAddress { get; set; }

        [Required]
        public int HotelPhoneNumber { get; set; }

        [DefaultValue(false)]
        public bool HasSpa { get; set; }

        [DefaultValue(false)]
        public bool HasGolfCourse { get; set; }

        [DefaultValue(false)]
        public bool HasRooftopBar { get; set; }

        public int NumberOfStars { get; set; }
    }
}
