namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedCalenderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calendars", "StateTime", c => c.String());
            AddColumn("dbo.Calendars", "EndTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calendars", "EndTime");
            DropColumn("dbo.Calendars", "StateTime");
        }
    }
}
