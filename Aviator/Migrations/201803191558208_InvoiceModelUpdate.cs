namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "SplitTimeBilled", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "SplitTimeBilled");
        }
    }
}
