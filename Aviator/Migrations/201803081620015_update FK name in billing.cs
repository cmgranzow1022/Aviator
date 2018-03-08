namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFKnameinbilling : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        AircraftId = c.Int(nullable: false),
                        Destination = c.String(),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.FlightId)
                .ForeignKey("dbo.Planes", t => t.AircraftId, cascadeDelete: true)
                .Index(t => t.AircraftId);
            
            CreateTable(
                "dbo.Planes",
                c => new
                    {
                        PlaneId = c.Int(nullable: false, identity: true),
                        TailNumber = c.String(),
                        TotalEngineHours = c.Double(nullable: false),
                        TotalHobbsHours = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PlaneId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        MemberRole = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MemberId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Flights", "AircraftId", "dbo.Planes");
            DropIndex("dbo.Members", new[] { "UserId" });
            DropIndex("dbo.Flights", new[] { "AircraftId" });
            DropTable("dbo.Members");
            DropTable("dbo.Planes");
            DropTable("dbo.Flights");
        }
    }
}
