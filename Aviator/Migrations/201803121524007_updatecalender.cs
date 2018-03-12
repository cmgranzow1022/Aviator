namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecalender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calendars", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Calendars", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Calendars", "Start");
            DropColumn("dbo.Calendars", "End");
            DropColumn("dbo.Calendars", "ThemeColor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Calendars", "ThemeColor", c => c.String());
            AddColumn("dbo.Calendars", "End", c => c.DateTime(nullable: false));
            AddColumn("dbo.Calendars", "Start", c => c.DateTime(nullable: false));
            DropColumn("dbo.Calendars", "EndDate");
            DropColumn("dbo.Calendars", "StartDate");
        }
    }
}
