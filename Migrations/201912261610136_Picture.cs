namespace ChatAppTest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Picture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProfilePicture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProfilePicture");
        }
    }
}
