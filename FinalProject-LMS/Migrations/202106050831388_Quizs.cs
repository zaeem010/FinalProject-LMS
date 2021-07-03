namespace FinalProject_LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quizs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quiz",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Courseid = c.Int(nullable: false),
                        QuizName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.QuizChild",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Courseid = c.Int(nullable: false),
                        Questions = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuizChild");
            DropTable("dbo.Quiz");
        }
    }
}
