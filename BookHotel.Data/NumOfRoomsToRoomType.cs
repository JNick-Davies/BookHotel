using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Data
{
    public class NumOfRoomsToRoomType
    {
        //joining table for Reservation to roomNumber
        [Key]
        public int NumOfRoomsID { get; set; }
        [ForeignKey(nameof(NumOfRoomsID))]
        public virtual Reservation Reservation { get; set; }

        [Key]
        public int roomNumber { get; set; }
        //[ForeignKey(nameof(roomNumber))]
    }
}
