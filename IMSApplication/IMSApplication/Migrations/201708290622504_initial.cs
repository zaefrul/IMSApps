namespace IMSApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "User_Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "User_Ic", c => c.String());
            AddColumn("dbo.AspNetUsers", "User_Phone", c => c.String());
            AddColumn("dbo.AspNetUsers", "User_Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "User_Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "User_Status");
            DropColumn("dbo.AspNetUsers", "User_Address");
            DropColumn("dbo.AspNetUsers", "User_Phone");
            DropColumn("dbo.AspNetUsers", "User_Ic");
            DropColumn("dbo.AspNetUsers", "User_Name");
        }
    }
}
