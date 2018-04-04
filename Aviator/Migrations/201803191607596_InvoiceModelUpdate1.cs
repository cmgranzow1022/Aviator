namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceModelUpdate1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Invoices", "SplitTimeBilled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "SplitTimeBilled", c => c.Double(nullable: false));
        }
    }
}
