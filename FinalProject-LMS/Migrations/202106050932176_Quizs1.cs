namespace FinalProject_LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quizs1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quiz", "Quizid", c => c.Int(nullable: false));
            AddColumn("dbo.QuizChild", "Quizid", c => c.Int(nullable: false));
            DropColumn("dbo.QuizChild", "Courseid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuizChild", "Courseid", c => c.Int(nullable: false));
            DropColumn("dbo.QuizChild", "Quizid");
            DropColumn("dbo.Quiz", "Quizid");
        }
    }
}
