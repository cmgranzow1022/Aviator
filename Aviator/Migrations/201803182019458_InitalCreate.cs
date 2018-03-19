namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
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
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        AircraftNumber = c.String(),
                        Destination = c.String(),
                        Date = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FlightId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceKey = c.Int(nullable: false, identity: true),
                        MemberBilledId = c.Int(nullable: false),
                        HourlyFlightRate = c.Double(nullable: false),
                        HoursBilled = c.Double(nullable: false),
                        HoursFlown = c.Double(nullable: false),
                        MonthlyDues = c.Double(nullable: false),
                        TotalAmountOwed = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceKey)
                .ForeignKey("dbo.Members", t => t.MemberBilledId, cascadeDelete: true)
                .Index(t => t.MemberBilledId);
            
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
                "dbo.PostFlights",
                c => new
                    {
                        PostFlightId = c.Int(nullable: false, identity: true),
                        FlightIdentification = c.Int(nullable: false),
                        EndingEngineHours = c.Double(nullable: false),
                        EndingHobbsHours = c.Double(nullable: false),
                        Squawks = c.String(),
                        SplitTime = c.Boolean(nullable: false),
                        SplitTimePilotId = c.Int(),
                    })
                .PrimaryKey(t => t.PostFlightId)
                .ForeignKey("dbo.Flights", t => t.FlightIdentification, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.SplitTimePilotId)
                .Index(t => t.FlightIdentification)
                .Index(t => t.SplitTimePilotId);
            
            CreateTable(
                "dbo.PreFlights",
                c => new
                    {
                        PreFlightId = c.Int(nullable: false, identity: true),
                        FlightIdentification = c.Int(nullable: false),
                        StartingEngineHours = c.Double(nullable: false),
                        StartingHobbsHours = c.Double(nullable: false),
                        StartingOilLevel = c.Double(nullable: false),
                        AmountOilAdded = c.Double(nullable: false),
                        MaintenanceFlight = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PreFlightId)
                .ForeignKey("dbo.Flights", t => t.FlightIdentification, cascadeDelete: true)
                .Index(t => t.FlightIdentification);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PreFlights", "FlightIdentification", "dbo.Flights");
            DropForeignKey("dbo.PostFlights", "SplitTimePilotId", "dbo.Members");
            DropForeignKey("dbo.PostFlights", "FlightIdentification", "dbo.Flights");
            DropForeignKey("dbo.Invoices", "MemberBilledId", "dbo.Members");
            DropForeignKey("dbo.Billings", "PilotId", "dbo.Members");
            DropForeignKey("dbo.Members", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Billings", "FlightToBillId", "dbo.Flights");
            DropForeignKey("dbo.Flights", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PreFlights", new[] { "FlightIdentification" });
            DropIndex("dbo.PostFlights", new[] { "SplitTimePilotId" });
            DropIndex("dbo.PostFlights", new[] { "FlightIdentification" });
            DropIndex("dbo.Invoices", new[] { "MemberBilledId" });
            DropIndex("dbo.Members", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Flights", new[] { "UserId" });
            DropIndex("dbo.Billings", new[] { "FlightToBillId" });
            DropIndex("dbo.Billings", new[] { "PilotId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PreFlights");
            DropTable("dbo.PostFlights");
            DropTable("dbo.Planes");
            DropTable("dbo.Invoices");
            DropTable("dbo.Calendars");
            DropTable("dbo.Members");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Flights");
            DropTable("dbo.Billings");
        }
    }
}
