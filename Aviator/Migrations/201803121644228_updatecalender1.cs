namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecalender1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calendars", "color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calendars", "color");
        }
    }
}
