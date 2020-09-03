using BookHotel.Data;
using BookHotel.Models.RoomNumber;
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

        public bool CreateRoom(RoomNumberCreate model)
        {
            var entity =
                new RoomNumber()
                {
                    roomId = model.roomId,
                    King = model.King,
                    Queen = model.Queen,
                    IsCityView = model.IsCityView,
                    IsRiverView = model.IsRiverView,
                    IsSuite = model.IsSuite,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.RoomNumbers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RoomNumberList> GetRoomNumbers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .RoomNumbers
                        //.Where(e => e.StaffIdLogin == _userId)
                        .Select(
                            e =>
                                new RoomNumberList
                                {
                                    roomId = e.roomId,
                                    King = e.King,
                                    Queen = e.Queen,
                                    IsCityView = e.IsCityView,
                                    IsRiverView = e.IsRiverView,
                                    IsSuite = e.IsSuite,
                                }
                        );
                return query.ToArray();
            }
        }

        
        public bool UpdateRoomNumber(RoomNumberEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RoomNumbers
                        .Single(e => e.roomId == model.roomId);
                entity.roomId = model.roomId;
                entity.King = model.King;
                entity.Queen = model.Queen;
                entity.IsCityView = model.IsCityView;
                entity.IsRiverView = model.IsRiverView;
                entity.IsSuite = model.IsSuite;
                return ctx.SaveChanges() == 1;
            }
        }
        /*public bool DeleteRoomNumber(int ReservationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .RoomNumbers
                            .Single(e => e.roomId == roomId );
                ctx.RoomNumbers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }*/
    }
}
