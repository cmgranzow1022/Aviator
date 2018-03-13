namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNullables2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PostFlights", "EndingEngineHours", c => c.Double(nullable: false));
            AlterColumn("dbo.PostFlights", "EndingHobbsHours", c => c.Double(nullable: false));
            AlterColumn("dbo.PreFlights", "StartingEngineHours", c => c.Double(nullable: false));
            AlterColumn("dbo.PreFlights", "StartingHobbsHours", c => c.Double(nullable: false));
            AlterColumn("dbo.PreFlights", "AmountOilAdded", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PreFlights", "AmountOilAdded", c => c.Double());
            AlterColumn("dbo.PreFlights", "StartingHobbsHours", c => c.Double());
            AlterColumn("dbo.PreFlights", "StartingEngineHours", c => c.Double());
            AlterColumn("dbo.PostFlights", "EndingHobbsHours", c => c.Double());
            AlterColumn("dbo.PostFlights", "EndingEngineHours", c => c.Double());
        }
    }
}
