namespace IMSApps_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class varietyaddqty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Varieties", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Varieties", "Quantity");
        }
    }
}
