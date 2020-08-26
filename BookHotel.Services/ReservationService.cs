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
        private readonly int _userId;

        public ReservationService(int userId)
        {
            _userId = userId;
        }

        public bool CreateReservation(ReservationCreate model)
        {
            var entity =
                new Reservation()
                {
                    StaffLoginId = _userId,
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

        public IEnumerable<ReservationListItem> GetReservations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reservations
                        .Where(e => e.StaffLoginId == _userId)
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
    }
}
