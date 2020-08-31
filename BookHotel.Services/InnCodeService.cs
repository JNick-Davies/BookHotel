using BookHotel.Data;
using BookHotel.Models.InnCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Services
{
    public class InnCodeService
    {
        private readonly Guid _userid;

        public InnCodeService(Guid userId)
        {
            _userid = userId;
        }

        public bool CreateCrime(InnCodeCreate model)
        {
            var entity =
                new InnCode()
                {
                    HotelInnCode = model.HotelInnCode,
                    HotelName = model.HotelName,
                    HotelAddress = model.HotelAddress,
                    HotelPhoneNumber = model.HotelPhoneNumber,
                    NumberOfStars = model.NumberOfStars,
                    HasGolfCourse = model.HasGolfCourse,
                    HasRooftopBar = model.HasRooftopBar,
                    HasSpa = model.HasSpa,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Inncodes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<InnCode> GetInnCodes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Inncodes
                        .Select(e =>
                            new InnCodeList()
                            {
                                HotelInnCode = e.HotelInnCode,
                                HotelName = e.HotelName,
                                HotelAddress = e.HotelAddress,
                                HotelPhoneNumber = e.HotelPhoneNumber,
                                NumberOfStars = e.NumberOfStars,
                                HasGolfCourse = e.HasGolfCourse,
                                HasRooftopBar = e.HasRooftopBar,
                                HasSpa = e.HasSpa,
                            }

                        );
                return query.ToArray();
            }
        }

        /*public bool EditInnCode(InnCodeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Inncodes
                        .Single(e => e.HotelInnCode == model.InnCode);
                entity.HotelInnCode =model.HotelInnCode;
                entity.HotelName = model.HotelName;
                entity.HotelAddress = model.HotelAddress;
                entity.HotelPhoneNumber = model.HotelPhoneNumber;
                entity.NumberOfStars = model.NumberOfStars;
                entity.HasGolfCourse = model.HasGolfCourse;
                entity.HasRooftopBar = model.HasRooftopBar;
                entity.HasSpa = model.HasSpa;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteInnCode(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Inncodes
                        .Single(e => e.HotelInnCode == id);
                ctx..Inncodes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }*/
    }
}
