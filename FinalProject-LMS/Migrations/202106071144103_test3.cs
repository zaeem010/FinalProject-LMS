namespace FinalProject_LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "StdName", c => c.String());
            DropColumn("dbo.Tests", "Stdid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "Stdid", c => c.Int(nullable: false));
            DropColumn("dbo.Tests", "StdName");
        }
    }
}
