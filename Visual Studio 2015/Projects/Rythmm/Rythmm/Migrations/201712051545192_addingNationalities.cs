namespace Rythmm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingNationalities : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (1, 'British')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (2, 'American')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (3, 'French')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (4, 'Spanish')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (5, 'German')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (6, 'Italian')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (7, 'Swedish')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (8, 'Dutch')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (9, 'Indian')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (10, 'Chinese')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (11, 'Japanese')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (12, 'Kenyan')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (13, 'Brazilian')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (14, 'Canadian')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (15, 'Greek')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (16, 'Russian')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (17, 'Norweigan')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (18, 'Finnish')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (19, 'Danish')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (20, 'Czech')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (21, 'Polish')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (22, 'Latvian')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (23, 'Serbian')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (24, 'Estonian')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (25, 'Croation')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (26, 'Korean')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (27, 'Egyptian')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (28, 'Mexican')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (29, 'Romanian')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (30, 'Bulgarian')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (31, 'Viatnamese')");
            Sql("INSERT INTO Nationalities (Id, Name) VALUES (32, 'Jamaican')");
        }
        
        public override void Down()
        {
        }
    }
}
