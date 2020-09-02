namespace BookHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationLoginUser",
                c => new
                    {
                        StaffIdLogin = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserHotelInnCode = c.String(),
                    })
                .PrimaryKey(t => t.StaffIdLogin);
            
            CreateTable(
                "dbo.InnCode",
                c => new
                    {
                        HotelInnCode = c.String(nullable: false, maxLength: 128),
                        HotelName = c.String(nullable: false),
                        HotelAddress = c.String(nullable: false),
                        HotelPhoneNumber = c.Int(nullable: false),
                        HasSpa = c.Boolean(nullable: false),
                        HasGolfCourse = c.Boolean(nullable: false),
                        HasRooftopBar = c.Boolean(nullable: false),
                        NumberOfStars = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HotelInnCode);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        ConfirmationNumber = c.Int(nullable: false),
                        InnCode = c.String(maxLength: 128),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ArrivialDate = c.DateTime(nullable: false),
                        NumberOfNights = c.Int(nullable: false),
                        NumberOfRooms = c.Int(nullable: false),
                        StaffIdLogin = c.Guid(nullable: false),
                        GuestFirstName = c.String(),
                        GuestlastName = c.String(),
                        GuestEmail = c.String(),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.ApplicationLoginUser", t => t.StaffIdLogin, cascadeDelete: true)
                .ForeignKey("dbo.InnCode", t => t.InnCode)
                .Index(t => t.InnCode)
                .Index(t => t.StaffIdLogin);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.RoomNumber",
                c => new
                    {
                        roomId = c.Int(nullable: false),
                        King = c.Boolean(nullable: false),
                        Queen = c.Boolean(nullable: false),
                        IsCityView = c.Boolean(nullable: false),
                        IsRiverView = c.Boolean(nullable: false),
                        IsSuite = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.roomId)
                .ForeignKey("dbo.NumOfRoomsToRoomType", t => t.roomId)
                .Index(t => t.roomId);
            
            CreateTable(
                "dbo.NumOfRoomsToRoomType",
                c => new
                    {
                        roomNumber = c.Int(nullable: false, identity: true),
                        NumOfRoomsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.roomNumber)
                .ForeignKey("dbo.Reservation", t => t.NumOfRoomsID, cascadeDelete: true)
                .Index(t => t.NumOfRoomsID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.RoomNumber", "roomId", "dbo.NumOfRoomsToRoomType");
            DropForeignKey("dbo.NumOfRoomsToRoomType", "NumOfRoomsID", "dbo.Reservation");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Reservation", "InnCode", "dbo.InnCode");
            DropForeignKey("dbo.Reservation", "StaffIdLogin", "dbo.ApplicationLoginUser");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.NumOfRoomsToRoomType", new[] { "NumOfRoomsID" });
            DropIndex("dbo.RoomNumber", new[] { "roomId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Reservation", new[] { "StaffIdLogin" });
            DropIndex("dbo.Reservation", new[] { "InnCode" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.NumOfRoomsToRoomType");
            DropTable("dbo.RoomNumber");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Reservation");
            DropTable("dbo.InnCode");
            DropTable("dbo.ApplicationLoginUser");
        }
    }
}
