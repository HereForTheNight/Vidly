namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [DrivingLicense], [Phone], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'68b21ffe-d401-4a65-a117-9c6503c8eabd', NULL, NULL, N'test@domain.com', 0, N'ADb/I6k3sFBic/EiSTLqawXLM+3Qs+o/POvuHHE2OaTS68chVJxDeo5drTwaCWAt1A==', N'549b9a82-6790-4683-9168-b47ef93bc04b', NULL, 0, 0, NULL, 1, 0, N'test@domain.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [DrivingLicense], [Phone], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7ab8f593-9aca-413c-911b-25e2c13a297d', N'DL', N'PhoneAdmin', N'admin@vidly.com', 0, N'APqmlpf8+LWM0nXTH0YuZaSeuD9z5w0jPvyy8izQC+RNNLkQN53p0uwq7pQf0jtBWg==', N'115c188f-e5f5-465e-a002-63b3cfb63e06', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0a19e91a-7b86-49d3-a56d-5e7bb7701b52', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7ab8f593-9aca-413c-911b-25e2c13a297d', N'0a19e91a-7b86-49d3-a56d-5e7bb7701b52')
");
        }
        
        public override void Down()
        {
        }
    }
}
