namespace FinalProject_LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Testid = c.Int(nullable: false),
                        Courseid = c.Int(nullable: false),
                        Quizid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TestChilds",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Testid = c.Int(nullable: false),
                        Questions = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestChilds");
            DropTable("dbo.Tests");
        }
    }
}
