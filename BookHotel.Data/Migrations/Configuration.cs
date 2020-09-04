﻿namespace BookHotel.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    internal sealed class Configuration : DbMigrationsConfiguration<BookHotel.Data.ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookHotel.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Inncodes.AddOrUpdate(x => x.HotelInnCode,
                new InnCode { HotelInnCode = "INDMS", HotelName = "Hooiser House on Main", HotelAddress = "101 Main Street", HotelPhoneNumber = 5556789, HasSpa = false, HasGolfCourse = false, HasRooftopBar = true, NumberOfStars = 3 },
                new InnCode { HotelInnCode = "INDCD", HotelName = "Carmel Delights Resort and Spa", HotelAddress = "479 Carmel Drive", HotelPhoneNumber = 5555678, HasSpa = true, HasGolfCourse = true, HasRooftopBar = true, NumberOfStars = 5 },
                new InnCode { HotelInnCode = "INDAP", HotelName = "Indianapolis Inn at the Airport", HotelAddress = "324 Wier Drive", HotelPhoneNumber = 5552345, HasSpa = false, HasGolfCourse = false, HasRooftopBar = false, NumberOfStars = 2 },
                new InnCode { HotelInnCode = "INDFQ", HotelName = "Fishers' Quarters", HotelAddress = "871 116th Street", HotelPhoneNumber = 5550782, HasSpa = true, HasGolfCourse = false, HasRooftopBar = true, NumberOfStars = 4 },
                new InnCode { HotelInnCode = "INDZS", HotelName = "Zionsville Manor at Cemetery Creek", HotelAddress = "800 Cemetery Trace", HotelPhoneNumber = 5556549, HasSpa = true, HasGolfCourse = true, HasRooftopBar = true, NumberOfStars = 5}
                        );

            /*context.Reservations.AddOrUpdate(x => x.ReservationId,
                new Reservation { ConfirmationNumber = 12345678, InnCode = "INDMS", Rate = 149.99m, ArrivialDate = new DateTime(2020, 10, 02), NumberOfNights = 2, NumberOfRooms = 1, GuestFirstName = "Ryan", GuestlastName = "Sanchez"},
                new Reservation { ConfirmationNumber = 12345679, InnCode = "INDFQ", Rate = 179.99m, ArrivialDate = new DateTime(2020, 10,09), NumberOfNights = 2, NumberOfRooms = 2, GuestFirstName = "Andrea", GuestlastName = "McKenzie" }
            );*/
        }
    }
}