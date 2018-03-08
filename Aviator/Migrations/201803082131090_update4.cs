namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PreFlights", "FlightIdentification", "dbo.Flights");
            DropIndex("dbo.PreFlights", new[] { "FlightIdentification" });
            AlterColumn("dbo.PreFlights", "FlightIdentification", c => c.Int());
            CreateIndex("dbo.PreFlights", "FlightIdentification");
            AddForeignKey("dbo.PreFlights", "FlightIdentification", "dbo.Flights", "FlightId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PreFlights", "FlightIdentification", "dbo.Flights");
            DropIndex("dbo.PreFlights", new[] { "FlightIdentification" });
            AlterColumn("dbo.PreFlights", "FlightIdentification", c => c.Int(nullable: false));
            CreateIndex("dbo.PreFlights", "FlightIdentification");
            AddForeignKey("dbo.PreFlights", "FlightIdentification", "dbo.Flights", "FlightId", cascadeDelete: true);
        }
    }
}
