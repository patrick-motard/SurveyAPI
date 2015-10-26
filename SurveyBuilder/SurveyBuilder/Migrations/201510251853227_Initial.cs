namespace SurveyBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionObjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        Answer = c.String(),
                        Survey_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Surveys", t => t.Survey_Id)
                .Index(t => t.Survey_Id);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(nullable: false),
                        CompletedMessage = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionObjects", "Survey_Id", "dbo.Surveys");
            DropIndex("dbo.QuestionObjects", new[] { "Survey_Id" });
            DropTable("dbo.Surveys");
            DropTable("dbo.QuestionObjects");
        }
    }
}
