namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedinvoiceModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "HourlyFlightRate", c => c.Double(nullable: false));
            AddColumn("dbo.Invoices", "HoursFlown", c => c.Double(nullable: false));
            AddColumn("dbo.Invoices", "TotalAmountOwed", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "TotalAmountOwed");
            DropColumn("dbo.Invoices", "HoursFlown");
            DropColumn("dbo.Invoices", "HourlyFlightRate");
        }
    }
}
