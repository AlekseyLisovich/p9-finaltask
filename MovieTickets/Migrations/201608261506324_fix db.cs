namespace MovieTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Image", c => c.Binary(nullable: false));
            AlterColumn("dbo.Movies", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Price", c => c.Double());
            AlterColumn("dbo.Movies", "Image", c => c.Binary());
            AlterColumn("dbo.Movies", "Description", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}
