namespace BookHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedJoiningTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoomNumber", "roomId", "dbo.NumOfRoomsToRoomType");
            DropForeignKey("dbo.NumOfRoomsToRoomType", "NumOfRoomsID", "dbo.Reservation");
            DropForeignKey("dbo.NumOfRoomsToRoomType", "roomId", "dbo.RoomNumber");
            DropIndex("dbo.RoomNumber", new[] { "roomId" });
            DropIndex("dbo.NumOfRoomsToRoomType", new[] { "NumOfRoomsID" });
            DropPrimaryKey("dbo.RoomNumber");
            DropPrimaryKey("dbo.NumOfRoomsToRoomType");
            AddColumn("dbo.NumOfRoomsToRoomType", "ReservationId", c => c.Int(nullable: false));
            AddColumn("dbo.NumOfRoomsToRoomType", "roomId", c => c.Int(nullable: false));
            AlterColumn("dbo.RoomNumber", "roomId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.NumOfRoomsToRoomType", "NumOfRoomsID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RoomNumber", "roomId");
            AddPrimaryKey("dbo.NumOfRoomsToRoomType", "NumOfRoomsID");
            CreateIndex("dbo.NumOfRoomsToRoomType", "ReservationId");
            CreateIndex("dbo.NumOfRoomsToRoomType", "roomId");
            AddForeignKey("dbo.NumOfRoomsToRoomType", "roomId", "dbo.RoomNumber", "roomId", cascadeDelete: true);
            AddForeignKey("dbo.NumOfRoomsToRoomType", "ReservationId", "dbo.Reservation", "ReservationId", cascadeDelete: true);
            DropColumn("dbo.NumOfRoomsToRoomType", "roomNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NumOfRoomsToRoomType", "roomNumber", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.NumOfRoomsToRoomType", "ReservationId", "dbo.Reservation");
            DropForeignKey("dbo.NumOfRoomsToRoomType", "roomId", "dbo.RoomNumber");
            DropIndex("dbo.NumOfRoomsToRoomType", new[] { "roomId" });
            DropIndex("dbo.NumOfRoomsToRoomType", new[] { "ReservationId" });
            DropPrimaryKey("dbo.NumOfRoomsToRoomType");
            DropPrimaryKey("dbo.RoomNumber");
            AlterColumn("dbo.NumOfRoomsToRoomType", "NumOfRoomsID", c => c.Int(nullable: false));
            AlterColumn("dbo.RoomNumber", "roomId", c => c.Int(nullable: false));
            DropColumn("dbo.NumOfRoomsToRoomType", "roomId");
            DropColumn("dbo.NumOfRoomsToRoomType", "ReservationId");
            AddPrimaryKey("dbo.NumOfRoomsToRoomType", "roomNumber");
            AddPrimaryKey("dbo.RoomNumber", "roomId");
            CreateIndex("dbo.NumOfRoomsToRoomType", "NumOfRoomsID");
            CreateIndex("dbo.RoomNumber", "roomId");
            AddForeignKey("dbo.NumOfRoomsToRoomType", "roomId", "dbo.RoomNumber", "roomId", cascadeDelete: true);
            AddForeignKey("dbo.NumOfRoomsToRoomType", "NumOfRoomsID", "dbo.Reservation", "ReservationId", cascadeDelete: true);
            AddForeignKey("dbo.RoomNumber", "roomId", "dbo.NumOfRoomsToRoomType", "roomNumber");
        }
    }
}
