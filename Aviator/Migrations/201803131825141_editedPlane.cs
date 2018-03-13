namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedPlane : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Flights", "AircraftId", "dbo.Planes");
            DropIndex("dbo.Flights", new[] { "AircraftId" });
            AlterColumn("dbo.Flights", "AircraftId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Flights", "AircraftId", c => c.Int(nullable: false));
            CreateIndex("dbo.Flights", "AircraftId");
            AddForeignKey("dbo.Flights", "AircraftId", "dbo.Planes", "PlaneId", cascadeDelete: true);
        }
    }
}
