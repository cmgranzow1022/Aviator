namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEventCalendar1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        MemberMakingReservation = c.Int(nullable: false),
                        EventDescription = c.String(),
                        Start = c.String(),
                        End = c.String(),
                        ThemeColor = c.String(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Members", t => t.MemberMakingReservation, cascadeDelete: true)
                .Index(t => t.MemberMakingReservation);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calendars", "MemberMakingReservation", "dbo.Members");
            DropIndex("dbo.Calendars", new[] { "MemberMakingReservation" });
            DropTable("dbo.Calendars");
        }
    }
}
