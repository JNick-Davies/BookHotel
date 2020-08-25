namespace BookHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingUseId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservation", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservation", "UserId", c => c.String());
        }
    }
}
