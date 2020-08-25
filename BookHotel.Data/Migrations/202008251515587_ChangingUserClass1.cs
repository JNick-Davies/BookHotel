namespace BookHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingUserClass1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Reservation");
            AlterColumn("dbo.Reservation", "ReservationId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Reservation", "ReservationId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Reservation");
            AlterColumn("dbo.Reservation", "ReservationId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Reservation", "ReservationId");
        }
    }
}
