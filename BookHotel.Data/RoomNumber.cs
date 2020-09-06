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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int roomId { get; set; } //room number?
        public bool King { get; set; }
        public bool Queen { get; set; }

        [Display(Name = "City View")]
        public bool IsCityView { get; set; }
        [Display(Name = "River View")]
        public bool IsRiverView { get; set; }
        [Display(Name = "Suite")]
        public bool IsSuite { get; set; }
        public virtual ICollection<NumOfRoomsToRoomType> NumOfRoomsToRoomTypes { get; set; } //= new List<NumOfRoomsToRoomTypes>(); 
    }
}
