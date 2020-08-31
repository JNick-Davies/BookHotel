using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Services
{
    public class RoomNumberService
    {
        public class InnCodeService
        {
            private readonly Guid _userid;

            public InnCodeService(Guid userId)
            {
                _userid = userId;
            }
        }
    }
}
