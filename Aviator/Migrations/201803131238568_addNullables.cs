namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNullables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PostFlights", "SplitTime", c => c.Boolean());
            AlterColumn("dbo.PreFlights", "StartingEngineHours", c => c.Double());
            AlterColumn("dbo.PreFlights", "StartingHobbsHours", c => c.Double());
            AlterColumn("dbo.PreFlights", "AmountOilAdded", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PreFlights", "AmountOilAdded", c => c.Double(nullable: false));
            AlterColumn("dbo.PreFlights", "StartingHobbsHours", c => c.Double(nullable: false));
            AlterColumn("dbo.PreFlights", "StartingEngineHours", c => c.Double(nullable: false));
            AlterColumn("dbo.PostFlights", "SplitTime", c => c.Boolean(nullable: false));
        }
    }
}
