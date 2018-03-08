namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostFlights",
                c => new
                    {
                        PostFlightId = c.Int(nullable: false, identity: true),
                        Flight = c.Int(nullable: false),
                        EndingEngineHours = c.Double(nullable: false),
                        EndingHobbsHours = c.Double(nullable: false),
                        Squawks = c.String(),
                        SplitTime = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PostFlightId)
                .ForeignKey("dbo.Flights", t => t.Flight, cascadeDelete: true)
                .Index(t => t.Flight);
            
            CreateTable(
                "dbo.PreFlights",
                c => new
                    {
                        PreFlightId = c.Int(nullable: false, identity: true),
                        Flight = c.Int(nullable: false),
                        StartngEngineHours = c.Double(nullable: false),
                        StartingHobbsHours = c.Double(nullable: false),
                        StartingOilLevel = c.Double(nullable: false),
                        AmountOilAdded = c.Double(nullable: false),
                        MaintenanceFlight = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PreFlightId)
                .ForeignKey("dbo.Flights", t => t.Flight, cascadeDelete: true)
                .Index(t => t.Flight);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PreFlights", "Flight", "dbo.Flights");
            DropForeignKey("dbo.PostFlights", "Flight", "dbo.Flights");
            DropIndex("dbo.PreFlights", new[] { "Flight" });
            DropIndex("dbo.PostFlights", new[] { "Flight" });
            DropTable("dbo.PreFlights");
            DropTable("dbo.PostFlights");
        }
    }
}
