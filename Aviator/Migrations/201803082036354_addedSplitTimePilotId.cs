namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSplitTimePilotId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostFlights", "SplitTimePilotId", c => c.Int(nullable: false));
            CreateIndex("dbo.PostFlights", "SplitTimePilotId");
            AddForeignKey("dbo.PostFlights", "SplitTimePilotId", "dbo.Members", "MemberId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostFlights", "SplitTimePilotId", "dbo.Members");
            DropIndex("dbo.PostFlights", new[] { "SplitTimePilotId" });
            DropColumn("dbo.PostFlights", "SplitTimePilotId");
        }
    }
}
