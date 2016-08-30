namespace MovieTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cinema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Sessions = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieCinemas",
                c => new
                    {
                        Movie_ID = c.Int(nullable: false),
                        Cinema_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_ID, t.Cinema_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_ID, cascadeDelete: true)
                .ForeignKey("dbo.Cinemas", t => t.Cinema_Id, cascadeDelete: true)
                .Index(t => t.Movie_ID)
                .Index(t => t.Cinema_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieCinemas", "Cinema_Id", "dbo.Cinemas");
            DropForeignKey("dbo.MovieCinemas", "Movie_ID", "dbo.Movies");
            DropIndex("dbo.MovieCinemas", new[] { "Cinema_Id" });
            DropIndex("dbo.MovieCinemas", new[] { "Movie_ID" });
            DropTable("dbo.MovieCinemas");
            DropTable("dbo.Cinemas");
        }
    }
}
