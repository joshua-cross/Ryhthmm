namespace Rythmm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedAlbumIdToIntFromByte : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "GenreId", "dbo.Genres");
            DropIndex("dbo.Songs", new[] { "GenreId" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Songs", "GenreId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Songs", "GenreId");
            AddForeignKey("dbo.Songs", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "GenreId", "dbo.Genres");
            DropIndex("dbo.Songs", new[] { "GenreId" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Songs", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Songs", "GenreId");
            AddForeignKey("dbo.Songs", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
