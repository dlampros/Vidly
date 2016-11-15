namespace Vidly.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'60a6374d-efb9-49ea-a34a-1e94d809ee5f', N'guest@vidly.com', 0, N'AEcP7PuWXXWiLRCWyq+B7nYCDi64bim7f0uFxNTv9h1A21HgbnhpP/zX0wMeUQLhow==', N'73351da8-6fde-4cd7-b42e-5c2668cf0e09', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7699b702-3708-4fd1-93ad-66b65e1806c4', N'admin@vidly.com', 0, N'AAZjIM8KbfBCKgDH3esALGEz5iyjhroQPn07TwsWUgDB5qbpCU0HnHAqrp2Yob298g==', N'49a7e6e0-baa3-4b30-910c-44b0220c7694', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'207c9fe3-8402-4203-b68f-2049e0ea55d8', N'CanManageMovies')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7699b702-3708-4fd1-93ad-66b65e1806c4', N'207c9fe3-8402-4203-b68f-2049e0ea55d8')
                ");
        }

        public override void Down()
        {
        }
    }
}
