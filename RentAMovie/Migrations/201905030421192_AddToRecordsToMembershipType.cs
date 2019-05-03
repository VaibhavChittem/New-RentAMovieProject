namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToRecordsToMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("insert MembershipTypes(MembershipTypeName,Rate,DurationInMonth,Discount) values ('PayAsYouGo',0,0,0)");
            Sql("insert MembershipTypes(MembershipTypeName,Rate,DurationInMonth,Discount) values ('Monthly',100,1,5)");
            Sql("insert MembershipTypes(MembershipTypeName,Rate,DurationInMonth,Discount) values ('Quarterly',300,3,10)");
            Sql("insert MembershipTypes(MembershipTypeName,Rate,DurationInMonth,Discount) values ('Half-Yearly',600,6,15)");
            Sql("insert MembershipTypes(MembershipTypeName,Rate,DurationInMonth,Discount) values ('Yearly',1200,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
