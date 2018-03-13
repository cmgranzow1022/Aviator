namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNullables1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PostFlights", "EndingEngineHours", c => c.Double());
            AlterColumn("dbo.PostFlights", "EndingHobbsHours", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PostFlights", "EndingHobbsHours", c => c.Double(nullable: false));
            AlterColumn("dbo.PostFlights", "EndingEngineHours", c => c.Double(nullable: false));
        }
    }
}
