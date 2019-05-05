namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMembershipTypeData1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes " +
                "SET Name = 'Annually' " +
                "WHERE id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
