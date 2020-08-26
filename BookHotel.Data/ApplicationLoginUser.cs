using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Data
{
    public class ApplicationLoginUser
    {
        [Key]
        public Guid StaffIdLogin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserHotelInnCode { get; set; }

    }
}
