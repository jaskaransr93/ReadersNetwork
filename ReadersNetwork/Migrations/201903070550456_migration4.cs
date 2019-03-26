namespace ReadersNetwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "AnsweredOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Questions", "Added", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "BookAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reviews", "ReviewdOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "UserAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Author", c => c.String());
            AlterColumn("dbo.Books", "Name", c => c.String());
            DropColumn("dbo.Users", "UserAdded");
            DropColumn("dbo.Reviews", "ReviewdOn");
            DropColumn("dbo.Books", "BookAdded");
            DropColumn("dbo.Questions", "Added");
            DropColumn("dbo.Answers", "AnsweredOn");
        }
    }
}
