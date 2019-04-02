namespace Feedback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Content = c.String(),
                        Author = c.String(),
                        MessageThreadId = c.Int(nullable: false),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MessageThreads", t => t.MessageThreadId, cascadeDelete: true)
                .Index(t => t.MessageThreadId);
            
            CreateTable(
                "dbo.MessageThreads",
                c => new
                    {
                        MessageThreadId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.MessageThreadId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        AssignedToId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        AssociatedMessageId = c.Int(nullable: false),
                        Created = c.DateTime(),
                        Notes = c.String(maxLength: 1000),
                        Completed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AssignedToId, cascadeDelete: true)
                .ForeignKey("dbo.Messages", t => t.AssociatedMessageId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.AssignedToId)
                .Index(t => t.CategoryId)
                .Index(t => t.AssociatedMessageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Tasks", "AssociatedMessageId", "dbo.Messages");
            DropForeignKey("dbo.Tasks", "AssignedToId", "dbo.Admins");
            DropForeignKey("dbo.Messages", "MessageThreadId", "dbo.MessageThreads");
            DropForeignKey("dbo.Votes", "AdminId", "dbo.Admins");
            DropIndex("dbo.Tasks", new[] { "AssociatedMessageId" });
            DropIndex("dbo.Tasks", new[] { "CategoryId" });
            DropIndex("dbo.Tasks", new[] { "AssignedToId" });
            DropIndex("dbo.Messages", new[] { "MessageThreadId" });
            DropIndex("dbo.Votes", new[] { "AdminId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.MessageThreads");
            DropTable("dbo.Messages");
            DropTable("dbo.Categories");
            DropTable("dbo.Votes");
            DropTable("dbo.Admins");
        }
    }
}
