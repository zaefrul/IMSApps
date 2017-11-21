namespace IMSApps_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "User_FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "User_LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "User_Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "User_Phone", c => c.String());
            AddColumn("dbo.AspNetUsers", "User_Ic", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "User_Ic");
            DropColumn("dbo.AspNetUsers", "User_Phone");
            DropColumn("dbo.AspNetUsers", "User_Address");
            DropColumn("dbo.AspNetUsers", "User_LastName");
            DropColumn("dbo.AspNetUsers", "User_FirstName");
        }
    }
}
