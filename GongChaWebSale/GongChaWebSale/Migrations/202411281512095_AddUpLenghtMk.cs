namespace GongChaWebSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpLenghtMk : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.taikhoans", "MatKhau", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.taikhoans", "MatKhau", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
