using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Models.InnCodeTools
{
    public class InnCodeEdit
    {
        public string HotelInnCode { get; set; }

        public string HotelName { get; set; }

        public string HotelAddress { get; set; }

        public int HotelPhoneNumber { get; set; }

        public bool HasSpa { get; set; }

        public bool HasGolfCourse { get; set; }

        public bool HasRooftopBar { get; set; }

        public int NumberOfStars { get; set; }
    }
}
