namespace GongChaWebSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNgayTaoOnHD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.hoadons", "NgayTao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.hoadons", "NgayTao");
        }
    }
}
