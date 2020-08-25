﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Data
{
    public class RoomNumber
    {
        [Key]
        public int roomId { get; set; } //room number?
        public bool King { get; set; }
        public bool Queen { get; set; }
        public bool IsCityView { get; set; }
        public bool IsRiverView { get; set; }
        public bool IsSuite { get; set; }

    }
}