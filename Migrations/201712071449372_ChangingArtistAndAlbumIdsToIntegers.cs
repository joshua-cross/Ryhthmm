namespace Rythmm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingArtistAndAlbumIdsToIntegers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Songs", new[] { "Album_Id" });
            DropIndex("dbo.Songs", new[] { "Artist_Id" });
            DropColumn("dbo.Songs", "AlbumId");
            DropColumn("dbo.Songs", "ArtistId");
            RenameColumn(table: "dbo.Songs", name: "Album_Id", newName: "AlbumId");
            RenameColumn(table: "dbo.Songs", name: "Artist_Id", newName: "ArtistId");
            AlterColumn("dbo.Songs", "ArtistId", c => c.Int(nullable: false));
            AlterColumn("dbo.Songs", "AlbumId", c => c.Int(nullable: false));
            AlterColumn("dbo.Songs", "AlbumId", c => c.Int(nullable: false));
            AlterColumn("dbo.Songs", "ArtistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Songs", "ArtistId");
            CreateIndex("dbo.Songs", "AlbumId");
            AddForeignKey("dbo.Songs", "AlbumId", "dbo.Albums", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Songs", "ArtistId", "dbo.Artists", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Songs", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Songs", new[] { "AlbumId" });
            DropIndex("dbo.Songs", new[] { "ArtistId" });
            AlterColumn("dbo.Songs", "ArtistId", c => c.Int());
            AlterColumn("dbo.Songs", "AlbumId", c => c.Int());
            AlterColumn("dbo.Songs", "AlbumId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Songs", "ArtistId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Songs", name: "ArtistId", newName: "Artist_Id");
            RenameColumn(table: "dbo.Songs", name: "AlbumId", newName: "Album_Id");
            AddColumn("dbo.Songs", "ArtistId", c => c.Byte(nullable: false));
            AddColumn("dbo.Songs", "AlbumId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Songs", "Artist_Id");
            CreateIndex("dbo.Songs", "Album_Id");
            AddForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists", "Id");
            AddForeignKey("dbo.Songs", "Album_Id", "dbo.Albums", "Id");
        }
    }
}
