namespace MovieTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Image", c => c.Binary());
            DropColumn("dbo.Movies", "ImageURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "ImageURL", c => c.String());
            DropColumn("dbo.Movies", "Image");
        }
    }
}
