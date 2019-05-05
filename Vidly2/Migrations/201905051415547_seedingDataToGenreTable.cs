namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingDataToGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) " +
                "VALUES ('Action')");
            Sql("INSERT INTO Genres (Name) " +
                "VALUES ('Adventure')");
            Sql("INSERT INTO Genres (Name) " +
                "VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Name) " +
                "VALUES ('Drama')");
            Sql("INSERT INTO Genres (Name) " +
                "VALUES ('Sci-Fi')");
        }
        
        public override void Down()
        {
        }
    }
}
