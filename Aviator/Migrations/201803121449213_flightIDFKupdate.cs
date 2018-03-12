namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class flightIDFKupdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PostFlights", name: "Flight", newName: "FlightIdentification");
            RenameIndex(table: "dbo.PostFlights", name: "IX_Flight", newName: "IX_FlightIdentification");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PostFlights", name: "IX_FlightIdentification", newName: "IX_Flight");
            RenameColumn(table: "dbo.PostFlights", name: "FlightIdentification", newName: "Flight");
        }
    }
}
