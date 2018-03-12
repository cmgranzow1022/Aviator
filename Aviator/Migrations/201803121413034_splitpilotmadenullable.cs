namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class splitpilotmadenullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostFlights", "SplitTimePilotId", "dbo.Members");
            DropIndex("dbo.PostFlights", new[] { "SplitTimePilotId" });
            AlterColumn("dbo.PostFlights", "SplitTimePilotId", c => c.Int());
            CreateIndex("dbo.PostFlights", "SplitTimePilotId");
            AddForeignKey("dbo.PostFlights", "SplitTimePilotId", "dbo.Members", "MemberId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostFlights", "SplitTimePilotId", "dbo.Members");
            DropIndex("dbo.PostFlights", new[] { "SplitTimePilotId" });
            AlterColumn("dbo.PostFlights", "SplitTimePilotId", c => c.Int(nullable: false));
            CreateIndex("dbo.PostFlights", "SplitTimePilotId");
            AddForeignKey("dbo.PostFlights", "SplitTimePilotId", "dbo.Members", "MemberId", cascadeDelete: true);
        }
    }
}
