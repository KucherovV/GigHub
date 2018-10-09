namespace GigHub1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filterSettingsAdded1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FilterSettings");
            AlterColumn("dbo.FilterSettings", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.FilterSettings", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FilterSettings");
            AlterColumn("dbo.FilterSettings", "Id", c => c.Boolean(nullable: false));
            AddPrimaryKey("dbo.FilterSettings", "Id");
        }
    }
}
