namespace ReadersNetwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Follows", "FollowingUserId", "dbo.Users");
            DropForeignKey("dbo.Follows", "UserId", "dbo.Users");
            DropForeignKey("dbo.Follows", "User_Id", "dbo.Users");
            DropIndex("dbo.Follows", new[] { "UserId" });
            DropIndex("dbo.Follows", new[] { "FollowingUserId" });
            DropIndex("dbo.Follows", new[] { "User_Id" });
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FollowerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.FollowerId })
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.FollowerId)
                .Index(t => t.UserId)
                .Index(t => t.FollowerId);
            
            AddColumn("dbo.Posts", "PostedTime", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Answers", "UserId");
            AddForeignKey("dbo.Answers", "UserId", "dbo.Users", "Id", cascadeDelete: true);
           // DropTable("dbo.Follows");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FollowingUserId = c.String(nullable: false, maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.FollowingUserId });
            
            DropForeignKey("dbo.Answers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Followers", "FollowerId", "dbo.Users");
            DropForeignKey("dbo.Followers", "UserId", "dbo.Users");
            DropIndex("dbo.Followers", new[] { "FollowerId" });
            DropIndex("dbo.Followers", new[] { "UserId" });
            DropIndex("dbo.Answers", new[] { "UserId" });
            DropColumn("dbo.Posts", "PostedTime");
            DropTable("dbo.Followers");
            CreateIndex("dbo.Follows", "User_Id");
            CreateIndex("dbo.Follows", "FollowingUserId");
            CreateIndex("dbo.Follows", "UserId");
            AddForeignKey("dbo.Follows", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Follows", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Follows", "FollowingUserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
