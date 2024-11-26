namespace GongChaWebSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKhuyenMai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhuyenMais", "NgayBatDau", c => c.DateTime(nullable: false));
            AddColumn("dbo.KhuyenMais", "NgayKetThuc", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhuyenMais", "NgayKetThuc");
            DropColumn("dbo.KhuyenMais", "NgayBatDau");
        }
    }
}
