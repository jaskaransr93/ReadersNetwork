namespace ReadersNetwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        QuesId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Text = c.String(),
                        Question_QuesId = c.Int(),
                        Question_BookId = c.Int(),
                    })
                .PrimaryKey(t => new { t.QuesId, t.UserId })
                .ForeignKey("dbo.Questions", t => new { t.Question_QuesId, t.Question_BookId })
                .Index(t => new { t.Question_QuesId, t.Question_BookId });
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuesId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Text = c.String(),
                    })
                .PrimaryKey(t => new { t.QuesId, t.BookId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.BookId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        Description = c.String(),
                        Genres = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Rating = c.Int(nullable: false),
                        ReviewText = c.String(),
                    })
                .PrimaryKey(t => new { t.BookId, t.UserId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 60),
                        Name = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        CoverPictureUrl = c.String(),
                        Summary = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Url = c.String(),
                        ImageUrl = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Questions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.Follows", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Follows", "UserId", "dbo.Users");
            DropForeignKey("dbo.Follows", "FollowingUserId", "dbo.Users");
            DropForeignKey("dbo.Reviews", "BookId", "dbo.Books");
            DropForeignKey("dbo.Questions", "BookId", "dbo.Books");
            DropForeignKey("dbo.Answers", new[] { "Question_QuesId", "Question_BookId" }, "dbo.Questions");
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Follows", new[] { "User_Id" });
            DropIndex("dbo.Follows", new[] { "FollowingUserId" });
            DropIndex("dbo.Follows", new[] { "UserId" });
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.Reviews", new[] { "BookId" });
            DropIndex("dbo.Questions", new[] { "UserId" });
            DropIndex("dbo.Questions", new[] { "BookId" });
            DropIndex("dbo.Answers", new[] { "Question_QuesId", "Question_BookId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Follows");
            DropTable("dbo.Users");
            DropTable("dbo.Reviews");
            DropTable("dbo.Books");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
