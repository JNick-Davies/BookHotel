using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Data
{
    public class RoomNumber
    {
        [Key]
        [Display(Name = "Room Number")]
        public int roomId { get; set; } //room number?
        public bool King { get; set; }
        public bool Queen { get; set; }
        public bool IsCityView { get; set; }
        public bool IsRiverView { get; set; }
        public bool IsSuite { get; set; }
        public virtual ICollection<NumOfRoomsToRoomType> NumOfRoomsToRoomTypes { get; set; } //= new List<NumOfRoomsToRoomTypes>(); 
    }
}
