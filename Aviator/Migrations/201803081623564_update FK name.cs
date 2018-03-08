namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFKname : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Billings",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        PilotId = c.Int(nullable: false),
                        FlightToBillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Flights", t => t.FlightToBillId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.PilotId, cascadeDelete: true)
                .Index(t => t.PilotId)
                .Index(t => t.FlightToBillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Billings", "PilotId", "dbo.Members");
            DropForeignKey("dbo.Billings", "FlightToBillId", "dbo.Flights");
            DropIndex("dbo.Billings", new[] { "FlightToBillId" });
            DropIndex("dbo.Billings", new[] { "PilotId" });
            DropTable("dbo.Billings");
        }
    }
}
