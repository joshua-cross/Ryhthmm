namespace Rythmm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Pop')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Rock')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Metal')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'R&B')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Hip-hop')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'rap')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Electronic')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Country')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Folk')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10, 'Indie')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (11, 'Alternative')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (12, 'Punk')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (13, 'Classical')");


        }

        public override void Down()
        {
        }
    }
}
