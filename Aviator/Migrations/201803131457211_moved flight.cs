namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movedflight : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Flights", "AircraftId", "dbo.Planes");
            DropForeignKey("dbo.PreFlights", "FlightIdentification", "dbo.Flights");
            DropIndex("dbo.Flights", new[] { "AircraftId" });
            DropIndex("dbo.PreFlights", new[] { "FlightIdentification" });
            DropPrimaryKey("dbo.PreFlights");
            AddColumn("dbo.PreFlights", "FlightId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.PreFlights", "AircraftId", c => c.Int(nullable: false));
            AddColumn("dbo.PreFlights", "Date", c => c.String());
            AddColumn("dbo.PreFlights", "Destination", c => c.String());
            AddPrimaryKey("dbo.PreFlights", "FlightId");
            CreateIndex("dbo.PreFlights", "AircraftId");
            AddForeignKey("dbo.PreFlights", "AircraftId", "dbo.Planes", "PlaneId", cascadeDelete: true);
            AddForeignKey("dbo.Billings", "FlightToBillId", "dbo.PreFlights", "FlightId", cascadeDelete: true);
            AddForeignKey("dbo.PostFlights", "FlightIdentification", "dbo.PreFlights", "FlightId", cascadeDelete: true);
            DropColumn("dbo.PreFlights", "PreFlightId");
            DropColumn("dbo.PreFlights", "FlightIdentification");
            DropTable("dbo.Flights");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        AircraftId = c.Int(nullable: false),
                        Destination = c.String(),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.FlightId);
            
            AddColumn("dbo.PreFlights", "FlightIdentification", c => c.Int());
            AddColumn("dbo.PreFlights", "PreFlightId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.PostFlights", "FlightIdentification", "dbo.PreFlights");
            DropForeignKey("dbo.Billings", "FlightToBillId", "dbo.PreFlights");
            DropForeignKey("dbo.PreFlights", "AircraftId", "dbo.Planes");
            DropIndex("dbo.PreFlights", new[] { "AircraftId" });
            DropPrimaryKey("dbo.PreFlights");
            DropColumn("dbo.PreFlights", "Destination");
            DropColumn("dbo.PreFlights", "Date");
            DropColumn("dbo.PreFlights", "AircraftId");
            DropColumn("dbo.PreFlights", "FlightId");
            AddPrimaryKey("dbo.PreFlights", "PreFlightId");
            CreateIndex("dbo.PreFlights", "FlightIdentification");
            CreateIndex("dbo.Flights", "AircraftId");
            AddForeignKey("dbo.PreFlights", "FlightIdentification", "dbo.Flights", "FlightId");
            AddForeignKey("dbo.Flights", "AircraftId", "dbo.Planes", "PlaneId", cascadeDelete: true);
        }
    }
}
