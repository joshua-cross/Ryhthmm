namespace Rythmm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedRequirmentFromAlbumName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "Name", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Albums", "Name", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
