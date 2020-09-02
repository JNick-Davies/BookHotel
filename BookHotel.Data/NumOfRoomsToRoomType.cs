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
        [ForeignKey(nameof(Reservation))]
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }


        [ForeignKey(nameof(RoomNumber))]
        public int roomId { get; set; }
        public virtual RoomNumber RoomNumber { get; set; }

    }
}
