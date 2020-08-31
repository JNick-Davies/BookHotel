using BookHotel.Data;
using BookHotel.Models.ApplicationLoginUser.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Services
{
    public class ApplicationLoginUserService
    {

        private readonly Guid _userId;

        public ApplicationLoginUserService(Guid userId)
        {
            _userId = userId;
        }

                public bool CreateApplicationLoginUser(ApplicationLoginUserCreate model)
        {
            var entity = new ApplicationLoginUser()
            {
                StaffIdLogin = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserHotelInnCode = model.UserHotelInnCode,

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ApplicationLoginUsers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
