using BookHotel.Data;
using BookHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Services
{
    public class ReservationService
    {
        private readonly Guid _userId;

        public ReservationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReservation(ReservationCreate model)
        {
            var entity =
                new Reservation()
                {
                    StaffIdLogin = _userId,
                    ReservationId = model.ReservationId,
                    ConfirmationNumber = model.ConfirmationNumber,
                    InnCode = model.InnCode,
                    Rate = model.Rate,
                    //UserID = model.UserID, //_user!~!
                    ArrivialDate = model.ArrivalDate,
                    NumberOfNights = model.NumberOfNights,
                    NumberOfRooms = model.NumberOfRooms,
                    //Title = model.Title,
                    //Content = model.Content,
                    //CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reservations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReservationListItem> GetReservationById()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reservations
                        .Where(e => e.StaffIdLogin == _userId)
                        .Select(
                            e =>
                                new ReservationListItem
                                {
                                    ReservationId = e.ReservationId,
                                    ConfirmationNumber = e.ConfirmationNumber,
                                    InnCode = e.InnCode,
                                    //Rate = e.Rate, not in list atm
                                    ArrivialDate = e.ArrivialDate,
                                    NumberOfNights = e.NumberOfNights,
                                    //NumberOfRooms = e.NumberOfRooms, not in list atm 
                                }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateReservation (ReservationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reservations
                        .Single(e => e.ReservationId == model.ReservationId && e.StaffIdLogin == _userId);
                entity.Rate = model.Rate;
                entity.ArrivialDate = model.ArrivialDate;
                entity.NumberOfNights = model.NumberOfNights;
                entity.NumberOfRooms = model.NumberOfRooms;
                entity.GuestFirstName = model.GuestFirstName;
                entity.GuestlastName = model.GuestlastName;
                entity.GuestEmail = model.GuestEmail;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteReservation(int ReservationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Reservations
                            .Single(e => e.ReservationId == ReservationId && e.StaffIdLogin == _userId);
                ctx.Reservations.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
