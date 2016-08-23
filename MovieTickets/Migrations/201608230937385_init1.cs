namespace MovieTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MovieOrderHistories", newName: "OrderHistoryMovies");
            DropPrimaryKey("dbo.OrderHistoryMovies");
            AddPrimaryKey("dbo.OrderHistoryMovies", new[] { "OrderHistory_ID", "Movie_ID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.OrderHistoryMovies");
            AddPrimaryKey("dbo.OrderHistoryMovies", new[] { "Movie_ID", "OrderHistory_ID" });
            RenameTable(name: "dbo.OrderHistoryMovies", newName: "MovieOrderHistories");
        }
    }
}
