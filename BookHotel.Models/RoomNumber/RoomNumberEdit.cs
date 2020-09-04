using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Models.RoomNumber
{
    public class RoomNumberEdit
    {
        [Display(Name = "Room number")]
        public int roomId { get; set; }
        public bool King { get; set; }
        public bool Queen { get; set; }
        public bool IsCityView { get; set; }
        public bool IsRiverView { get; set; }
        public bool IsSuite { get; set; }
    }
}
