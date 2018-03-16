namespace Aviator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedinvoiceModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceKey = c.Int(nullable: false, identity: true),
                        MemberBilledId = c.Int(nullable: false),
                        HoursBilled = c.Double(nullable: false),
                        MonthlyDues = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceKey)
                .ForeignKey("dbo.Members", t => t.MemberBilledId, cascadeDelete: true)
                .Index(t => t.MemberBilledId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "MemberBilledId", "dbo.Members");
            DropIndex("dbo.Invoices", new[] { "MemberBilledId" });
            DropTable("dbo.Invoices");
        }
    }
}
