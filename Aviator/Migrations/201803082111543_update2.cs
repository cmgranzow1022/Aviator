namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PreFlights", name: "Flight", newName: "FlightIdentification");
            RenameIndex(table: "dbo.PreFlights", name: "IX_Flight", newName: "IX_FlightIdentification");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PreFlights", name: "IX_FlightIdentification", newName: "IX_Flight");
            RenameColumn(table: "dbo.PreFlights", name: "FlightIdentification", newName: "Flight");
        }
    }
}
