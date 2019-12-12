namespace netmvc_relatable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Thumbnail", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Thumbnail");
        }
    }
}
