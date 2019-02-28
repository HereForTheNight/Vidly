namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMovieGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres (id, Genre) VALUES (1, 'Action')");
            Sql("INSERT INTO MovieGenres (id, Genre) VALUES (2, 'Thriller')");
            Sql("INSERT INTO MovieGenres (id, Genre) VALUES (3, 'Family')");
            Sql("INSERT INTO MovieGenres (id, Genre) VALUES (4, 'Romance')");
            Sql("INSERT INTO MovieGenres (id, Genre) VALUES (5, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
