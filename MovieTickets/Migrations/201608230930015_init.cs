namespace MovieTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderHistories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StatusID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        OrderStatus_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatus_ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.OrderStatus_ID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImageURL = c.String(),
                        Price = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleStatus = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MovieOrderHistories",
                c => new
                    {
                        Movie_ID = c.Int(nullable: false),
                        OrderHistory_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_ID, t.OrderHistory_ID })
                .ForeignKey("dbo.Movies", t => t.Movie_ID, cascadeDelete: true)
                .ForeignKey("dbo.OrderHistories", t => t.OrderHistory_ID, cascadeDelete: true)
                .Index(t => t.Movie_ID)
                .Index(t => t.OrderHistory_ID);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_ID = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_ID, t.User_ID })
                .ForeignKey("dbo.Roles", t => t.Role_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.Role_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleUsers", "User_ID", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.OrderHistories", "UserID", "dbo.Users");
            DropForeignKey("dbo.OrderHistories", "OrderStatus_ID", "dbo.OrderStatus");
            DropForeignKey("dbo.MovieOrderHistories", "OrderHistory_ID", "dbo.OrderHistories");
            DropForeignKey("dbo.MovieOrderHistories", "Movie_ID", "dbo.Movies");
            DropIndex("dbo.RoleUsers", new[] { "User_ID" });
            DropIndex("dbo.RoleUsers", new[] { "Role_ID" });
            DropIndex("dbo.MovieOrderHistories", new[] { "OrderHistory_ID" });
            DropIndex("dbo.MovieOrderHistories", new[] { "Movie_ID" });
            DropIndex("dbo.OrderHistories", new[] { "OrderStatus_ID" });
            DropIndex("dbo.OrderHistories", new[] { "UserID" });
            DropTable("dbo.RoleUsers");
            DropTable("dbo.MovieOrderHistories");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Movies");
            DropTable("dbo.OrderHistories");
        }
    }
}
