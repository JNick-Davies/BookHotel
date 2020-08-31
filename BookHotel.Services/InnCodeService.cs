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

        public CrimeDetail GetCrimeByCrimeId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Crimes
                        .Single(e => e.CrimeId == id);
                return new CrimeDetail()
                {
                    CrimeId = entity.CrimeId,
                    CrimeDescription = entity.CrimeDescription,
                    CrimeType = entity.CrimeType,
                    Penalty = entity.Penalty
                };

            }
        }
        public bool EditCrime(CrimeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Crimes
                        .Single(e => e.CrimeId == model.CrimeId);
                entity.CrimeDescription = model.CrimeDescription;
                entity.CrimeType = model.CrimeType;
                entity.Penalty = model.Penalty;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCrime(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Crimes
                        .Single(e => e.CrimeId == id);
                ctx.Crimes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
