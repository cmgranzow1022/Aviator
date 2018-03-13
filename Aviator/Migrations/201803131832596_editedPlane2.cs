namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedPlane2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "AircraftNumber", c => c.String());
            DropColumn("dbo.Flights", "AircraftId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "AircraftId", c => c.String());
            DropColumn("dbo.Flights", "AircraftNumber");
        }
    }
}
