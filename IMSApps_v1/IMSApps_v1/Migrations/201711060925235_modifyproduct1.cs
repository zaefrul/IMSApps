namespace IMSApps_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyproduct1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Varieties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sizes", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SizeId)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Varieties", "SizeId", "dbo.Sizes");
            DropForeignKey("dbo.Varieties", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Varieties", "ColorId", "dbo.Colors");
            DropIndex("dbo.Varieties", new[] { "ColorId" });
            DropIndex("dbo.Varieties", new[] { "SizeId" });
            DropIndex("dbo.Varieties", new[] { "ProductId" });
            DropTable("dbo.Sizes");
            DropTable("dbo.Colors");
            DropTable("dbo.Varieties");
        }
    }
}
