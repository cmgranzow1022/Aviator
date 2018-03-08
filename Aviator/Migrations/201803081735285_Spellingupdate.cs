namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Spellingupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PreFlights", "StartingEngineHours", c => c.Double(nullable: false));
            DropColumn("dbo.PreFlights", "StartngEngineHours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PreFlights", "StartngEngineHours", c => c.Double(nullable: false));
            DropColumn("dbo.PreFlights", "StartingEngineHours");
        }
    }
}
