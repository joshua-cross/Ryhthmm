namespace Rythmm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStringForSongs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Songs", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "Songs");
        }
    }
}
