namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedFlight11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Flights", "UserId");
            AddForeignKey("dbo.Flights", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flights", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Flights", new[] { "UserId" });
            DropColumn("dbo.Flights", "UserId");
        }
    }
}
