namespace GigHub1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filterSettingsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilterSettings",
                c => new
                    {
                        Id = c.Boolean(nullable: false),
                        FilterByAttend = c.Boolean(nullable: false),
                        FilterByFollow = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FilterSettings");
        }
    }
}
