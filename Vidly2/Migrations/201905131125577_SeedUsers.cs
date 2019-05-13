namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
                VALUES (N'251cbada-c317-4f1c-9fe6-fb3613724197', N'guest@vidly.com', 0, N'AIJy/oDWFs9g8MZQwvNDTUIy/N+QUNQohv0ff9IhOT95OMyOzmL4RvJToFQ1nvdEnw==', N'87cf4d36-f097-4db2-82ed-aadab95070a2', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
                VALUES (N'a66874d5-2c3c-4fa8-a3e0-4b4343ecb071', N'admin@vidly.com', 0, N'ANzULTX3SBgHwgzhyXNeMpQFUeAsHPZPPHbca+lUctWgsX7dLbHC8lP1x8xOyeRggQ==', N'2232007c-8295-4d38-9e1e-af3bb1381362', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) 
                VALUES (N'29433637-0e6d-4aff-a241-fd6444c18303', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) 
                VALUES (N'a66874d5-2c3c-4fa8-a3e0-4b4343ecb071', N'29433637-0e6d-4aff-a241-fd6444c18303')

                ");

            /** 
             *  1. add created users to the migration from dbo.AspNetUsers: guest@vidly.com, admin@vidly.com
             *  2. add roles from dbo.AspNetRoles
             *  3. add record that associate admin user to the new role from dbo.AspNetUserRoles
             *  4. delete entries from db in dbo.AspNetUsers and dbo.AspNetRoles
             **/

        }

        public override void Down()
        {
        }
    }
}
