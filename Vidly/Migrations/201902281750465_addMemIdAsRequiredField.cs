namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMemIdAsRequiredField : DbMigration
    {
        public override void Up()
        {
            
                AlterColumn("dbo.MembershipTypes", "Id", c => c.Byte(nullable: false));
            
        }
        
        public override void Down()
        {
        }
    }
}
