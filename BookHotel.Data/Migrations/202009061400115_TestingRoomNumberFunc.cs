namespace BookHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingRoomNumberFunc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NumOfRoomsToRoomType", "roomId", "dbo.RoomNumber");
            DropPrimaryKey("dbo.RoomNumber");
            AlterColumn("dbo.RoomNumber", "roomId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RoomNumber", "roomId");
            AddForeignKey("dbo.NumOfRoomsToRoomType", "roomId", "dbo.RoomNumber", "roomId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NumOfRoomsToRoomType", "roomId", "dbo.RoomNumber");
            DropPrimaryKey("dbo.RoomNumber");
            AlterColumn("dbo.RoomNumber", "roomId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RoomNumber", "roomId");
            AddForeignKey("dbo.NumOfRoomsToRoomType", "roomId", "dbo.RoomNumber", "roomId", cascadeDelete: true);
        }
    }
}
