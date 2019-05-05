namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMembershipTypeData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes " +
                "SET Name = 'Pay As You Go' " +
                "WHERE id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
