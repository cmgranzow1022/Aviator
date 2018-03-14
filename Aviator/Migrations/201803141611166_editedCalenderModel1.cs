namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedCalenderModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calendars", "StartTime", c => c.String());
            DropColumn("dbo.Calendars", "StateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Calendars", "StateTime", c => c.String());
            DropColumn("dbo.Calendars", "StartTime");
        }
    }
}
