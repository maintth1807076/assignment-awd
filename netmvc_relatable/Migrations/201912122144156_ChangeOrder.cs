namespace netmvc_relatable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CreatedAt", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CreatedAt", c => c.Long(nullable: false));
        }
    }
}
