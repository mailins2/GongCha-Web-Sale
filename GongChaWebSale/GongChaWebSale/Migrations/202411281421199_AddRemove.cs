namespace GongChaWebSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRemove : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.taikhoans", "SDT", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.taikhoans", "SDT", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
