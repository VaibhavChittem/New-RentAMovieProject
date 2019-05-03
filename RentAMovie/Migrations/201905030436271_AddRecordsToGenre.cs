namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecordsToGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert Genres(Name) values ('John')");
            Sql("insert Genres(Name) values ('Sam')");
            Sql("insert Genres(Name) values ('John')");
            Sql("insert Genres(Name) values ('John')");
            Sql("insert Genres(Name) values ('John')");
        }
        
        public override void Down()
        {
        }
    }
}
