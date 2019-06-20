namespace Project.SQLDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Objectives",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Description = c.String(),
                        StatusID = c.Int(nullable: false),
                        UserID = c.Guid(nullable: false),
                        Account_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .Index(t => t.StatusID)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        IsVerified = c.Boolean(nullable: false),
                        PermissionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permissions", t => t.PermissionID, cascadeDelete: true)
                .Index(t => t.PermissionID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Objectives", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Accounts", "PermissionID", "dbo.Permissions");
            DropForeignKey("dbo.Objectives", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.Accounts", new[] { "PermissionID" });
            DropIndex("dbo.Objectives", new[] { "Account_Id" });
            DropIndex("dbo.Objectives", new[] { "StatusID" });
            DropTable("dbo.Status");
            DropTable("dbo.Accounts");
            DropTable("dbo.Permissions");
            DropTable("dbo.Objectives");
        }
    }
}
