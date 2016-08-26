namespace MovieTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdb2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieComments", "PublishDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieComments", "PublishDate");
        }
    }
}
