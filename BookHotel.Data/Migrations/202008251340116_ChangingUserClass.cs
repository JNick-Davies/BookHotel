namespace BookHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingUserClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservation", "BookingUserId", c => c.Guid(nullable: false));
            DropColumn("dbo.Reservation", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservation", "UserId", c => c.Guid(nullable: false));
            DropColumn("dbo.Reservation", "BookingUserId");
        }
    }
}
