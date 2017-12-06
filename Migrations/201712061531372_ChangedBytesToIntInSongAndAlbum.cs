namespace Rythmm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedBytesToIntInSongAndAlbum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Songs", new[] { "AlbumId" });
            DropPrimaryKey("dbo.Albums");
            DropPrimaryKey("dbo.Songs");
            AddColumn("dbo.Songs", "Album_Id", c => c.Int());
            AlterColumn("dbo.Albums", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Songs", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Albums", "Id");
            AddPrimaryKey("dbo.Songs", "Id");
            CreateIndex("dbo.Songs", "Album_Id");
            AddForeignKey("dbo.Songs", "Album_Id", "dbo.Albums", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "Album_Id", "dbo.Albums");
            DropIndex("dbo.Songs", new[] { "Album_Id" });
            DropPrimaryKey("dbo.Songs");
            DropPrimaryKey("dbo.Albums");
            AlterColumn("dbo.Songs", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Albums", "Id", c => c.Byte(nullable: false));
            DropColumn("dbo.Songs", "Album_Id");
            AddPrimaryKey("dbo.Songs", "Id");
            AddPrimaryKey("dbo.Albums", "Id");
            CreateIndex("dbo.Songs", "AlbumId");
            AddForeignKey("dbo.Songs", "AlbumId", "dbo.Albums", "Id", cascadeDelete: true);
        }
    }
}
