namespace BookHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomNumberPropChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoomNumber", "RoomNumberRecord", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoomNumber", "RoomNumberRecord");
        }
    }
}
