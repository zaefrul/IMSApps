namespace IMSApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Addresses = c.String(),
                        Ic = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Total = c.Double(nullable: false),
                        Method = c.String(),
                        Tendered = c.Double(nullable: false),
                        Change = c.Double(nullable: false),
                        Refference = c.String(),
                        VoucherId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Vouchers", t => t.VoucherId, cascadeDelete: true)
                .Index(t => t.VoucherId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        VarietyId = c.Int(nullable: false),
                        ReceiptId = c.Int(nullable: false),
                        Salesperson = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        ChannelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Channels", t => t.ChannelId, cascadeDelete: true)
                .ForeignKey("dbo.Receipts", t => t.ReceiptId, cascadeDelete: true)
                .ForeignKey("dbo.Varieties", t => t.VarietyId, cascadeDelete: true)
                .Index(t => t.VarietyId)
                .Index(t => t.ReceiptId)
                .Index(t => t.ChannelId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Type = c.String(),
                        UserId = c.Int(nullable: false),
                        VarietyId = c.Int(nullable: false),
                        InvoiceItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Varieties", t => t.VarietyId, cascadeDelete: true)
                .Index(t => t.VarietyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "VarietyId", "dbo.Varieties");
            DropForeignKey("dbo.Sales", "VarietyId", "dbo.Varieties");
            DropForeignKey("dbo.Sales", "ReceiptId", "dbo.Receipts");
            DropForeignKey("dbo.Sales", "ChannelId", "dbo.Channels");
            DropForeignKey("dbo.Receipts", "VoucherId", "dbo.Vouchers");
            DropForeignKey("dbo.Receipts", "MemberId", "dbo.Members");
            DropIndex("dbo.Transactions", new[] { "VarietyId" });
            DropIndex("dbo.Sales", new[] { "ChannelId" });
            DropIndex("dbo.Sales", new[] { "ReceiptId" });
            DropIndex("dbo.Sales", new[] { "VarietyId" });
            DropIndex("dbo.Receipts", new[] { "MemberId" });
            DropIndex("dbo.Receipts", new[] { "VoucherId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Sales");
            DropTable("dbo.Vouchers");
            DropTable("dbo.Receipts");
            DropTable("dbo.Members");
            DropTable("dbo.Channels");
        }
    }
}
