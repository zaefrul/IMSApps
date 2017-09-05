namespace IMSApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstproject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Default = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                        Sell = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Varieties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sizes", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SizeId)
                .Index(t => t.ColorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Varieties", "SizeId", "dbo.Sizes");
            DropForeignKey("dbo.Varieties", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Varieties", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Varieties", new[] { "ColorId" });
            DropIndex("dbo.Varieties", new[] { "SizeId" });
            DropIndex("dbo.Varieties", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Varieties");
            DropTable("dbo.Sizes");
            DropTable("dbo.Products");
            DropTable("dbo.Colors");
            DropTable("dbo.Categories");
        }
    }
}
