namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEventCalendar2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Calendars", "Start", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Calendars", "End", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Calendars", "End", c => c.String());
            AlterColumn("dbo.Calendars", "Start", c => c.String());
        }
    }
}
