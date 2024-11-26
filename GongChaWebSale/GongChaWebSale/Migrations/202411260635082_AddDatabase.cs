namespace GongChaWebSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.banggias",
                c => new
                    {
                        MaSP = c.Int(nullable: false),
                        Size = c.String(nullable: false, maxLength: 1),
                        DonGia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.MaSP, t.Size })
                .ForeignKey("dbo.sanphams", t => t.MaSP, cascadeDelete: true)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.sanphams",
                c => new
                    {
                        MaSP = c.Int(nullable: false, identity: true),
                        TenSP = c.String(),
                        MaLoaiSP = c.Int(nullable: false),
                        Hinh = c.String(),
                        MoTa = c.String(),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.loaisps", t => t.MaLoaiSP, cascadeDelete: true)
                .Index(t => t.MaLoaiSP);
            
            CreateTable(
                "dbo.loaisps",
                c => new
                    {
                        MaLoaiSP = c.Int(nullable: false, identity: true),
                        TenLoaiSP = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.MaLoaiSP);
            
            CreateTable(
                "dbo.chitietdonhangs",
                c => new
                    {
                        MaDH = c.Int(nullable: false),
                        MaSP = c.Int(nullable: false),
                        Size = c.String(nullable: false, maxLength: 1),
                        MaTP = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        ThuTu = c.Int(nullable: false),
                        TongTienSP = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.MaDH, t.MaSP, t.Size, t.MaTP })
                .ForeignKey("dbo.donhangs", t => t.MaDH, cascadeDelete: true)
                .ForeignKey("dbo.sanphams", t => t.MaSP, cascadeDelete: true)
                .ForeignKey("dbo.toppings", t => t.MaTP, cascadeDelete: true)
                .Index(t => t.MaDH)
                .Index(t => t.MaSP)
                .Index(t => t.MaTP);
            
            CreateTable(
                "dbo.donhangs",
                c => new
                    {
                        MaDH = c.Int(nullable: false, identity: true),
                        TgDat = c.DateTime(nullable: false),
                        MaTK = c.Int(nullable: false),
                        GhiChu = c.String(),
                        MaTrangThai = c.Int(),
                        ThanhToan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaDH)
                .ForeignKey("dbo.taikhoans", t => t.MaTK, cascadeDelete: true)
                .ForeignKey("dbo.trangthaidonhangs", t => t.MaTrangThai)
                .Index(t => t.MaTK)
                .Index(t => t.MaTrangThai);
            
            CreateTable(
                "dbo.taikhoans",
                c => new
                    {
                        MaTK = c.Int(nullable: false, identity: true),
                        TenTK = c.String(nullable: false, maxLength: 10),
                        MatKhau = c.String(nullable: false, maxLength: 20),
                        HoTen = c.String(maxLength: 30),
                        NgaySinh = c.DateTime(),
                        GioiTinh = c.String(maxLength: 5),
                        DiaChi = c.String(maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 50),
                        SDT = c.String(nullable: false, maxLength: 10),
                        Hinh = c.String(),
                        MaLoaiTK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaTK)
                .ForeignKey("dbo.LoaiTaiKhoans", t => t.MaLoaiTK, cascadeDelete: true)
                .Index(t => t.MaLoaiTK);
            
            CreateTable(
                "dbo.LoaiTaiKhoans",
                c => new
                    {
                        MaLoaiTK = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(),
                    })
                .PrimaryKey(t => t.MaLoaiTK);
            
            CreateTable(
                "dbo.trangthaidonhangs",
                c => new
                    {
                        MaTrangThai = c.Int(nullable: false, identity: true),
                        TenTrangThai = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaTrangThai);
            
            CreateTable(
                "dbo.toppings",
                c => new
                    {
                        MaTP = c.Int(nullable: false, identity: true),
                        TenTP = c.String(),
                        DonGia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hinh = c.String(),
                    })
                .PrimaryKey(t => t.MaTP);
            
            CreateTable(
                "dbo.danhgias",
                c => new
                    {
                        MaDH = c.Int(nullable: false),
                        MaSP = c.Int(nullable: false),
                        MaTK = c.Int(nullable: false),
                        NgayDG = c.DateTime(nullable: false),
                        SoSao = c.Int(nullable: false),
                        NoiDung = c.String(),
                    })
                .PrimaryKey(t => new { t.MaDH, t.MaSP })
                .ForeignKey("dbo.donhangs", t => t.MaDH, cascadeDelete: false)
                .ForeignKey("dbo.sanphams", t => t.MaSP, cascadeDelete: false)
                .ForeignKey("dbo.taikhoans", t => t.MaTK, cascadeDelete: false)
                .Index(t => t.MaDH)
                .Index(t => t.MaSP)
                .Index(t => t.MaTK);
            
            CreateTable(
                "dbo.giohang_sanpham",
                c => new
                    {
                        MaGH = c.Int(nullable: false),
                        MaSP = c.Int(nullable: false),
                        Size = c.String(nullable: false, maxLength: 1),
                        MaTP = c.Int(nullable: false),
                        Duong = c.Int(),
                        Da = c.Int(),
                        SoLuong = c.Int(nullable: false),
                        TongTienSP = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.MaGH, t.MaSP, t.Size, t.MaTP })
                .ForeignKey("dbo.giohangs", t => t.MaGH, cascadeDelete: true)
                .ForeignKey("dbo.sanphams", t => t.MaSP, cascadeDelete: true)
                .ForeignKey("dbo.toppings", t => t.MaTP, cascadeDelete: true)
                .Index(t => t.MaGH)
                .Index(t => t.MaSP)
                .Index(t => t.MaTP);
            
            CreateTable(
                "dbo.giohangs",
                c => new
                    {
                        MaGH = c.Int(nullable: false, identity: true),
                        MaTK = c.Int(nullable: false),
                        NgayTao = c.DateTime(nullable: false),
                        TongTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaGH)
                .ForeignKey("dbo.taikhoans", t => t.MaTK, cascadeDelete: true)
                .Index(t => t.MaTK);
            
            CreateTable(
                "dbo.hoadons",
                c => new
                    {
                        MaHD = c.Int(nullable: false, identity: true),
                        MaDH = c.Int(nullable: false),
                        TongTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiamGia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThanhTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaTK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.donhangs", t => t.MaDH, cascadeDelete: false)
                .ForeignKey("dbo.taikhoans", t => t.MaTK, cascadeDelete: false)
                .Index(t => t.MaDH)
                .Index(t => t.MaTK);
            
            CreateTable(
                "dbo.KhuyenMais",
                c => new
                    {
                        Makm = c.String(nullable: false, maxLength: 128),
                        MaSP = c.Int(nullable: false),
                        Size = c.String(nullable: false, maxLength: 1),
                        Ptgiam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tenkm = c.String(),
                        Noidung = c.String(),
                    })
                .PrimaryKey(t => new { t.Makm, t.MaSP, t.Size })
                .ForeignKey("dbo.banggias", t => new { t.MaSP, t.Size }, cascadeDelete: false)
                .ForeignKey("dbo.sanphams", t => t.MaSP, cascadeDelete: false)
                .Index(t => new { t.MaSP, t.Size });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KhuyenMais", "MaSP", "dbo.sanphams");
            DropForeignKey("dbo.KhuyenMais", new[] { "MaSP", "Size" }, "dbo.banggias");
            DropForeignKey("dbo.hoadons", "MaTK", "dbo.taikhoans");
            DropForeignKey("dbo.hoadons", "MaDH", "dbo.donhangs");
            DropForeignKey("dbo.giohang_sanpham", "MaTP", "dbo.toppings");
            DropForeignKey("dbo.giohang_sanpham", "MaSP", "dbo.sanphams");
            DropForeignKey("dbo.giohang_sanpham", "MaGH", "dbo.giohangs");
            DropForeignKey("dbo.giohangs", "MaTK", "dbo.taikhoans");
            DropForeignKey("dbo.danhgias", "MaTK", "dbo.taikhoans");
            DropForeignKey("dbo.danhgias", "MaSP", "dbo.sanphams");
            DropForeignKey("dbo.danhgias", "MaDH", "dbo.donhangs");
            DropForeignKey("dbo.chitietdonhangs", "MaTP", "dbo.toppings");
            DropForeignKey("dbo.chitietdonhangs", "MaSP", "dbo.sanphams");
            DropForeignKey("dbo.chitietdonhangs", "MaDH", "dbo.donhangs");
            DropForeignKey("dbo.donhangs", "MaTrangThai", "dbo.trangthaidonhangs");
            DropForeignKey("dbo.donhangs", "MaTK", "dbo.taikhoans");
            DropForeignKey("dbo.taikhoans", "MaLoaiTK", "dbo.LoaiTaiKhoans");
            DropForeignKey("dbo.banggias", "MaSP", "dbo.sanphams");
            DropForeignKey("dbo.sanphams", "MaLoaiSP", "dbo.loaisps");
            DropIndex("dbo.KhuyenMais", new[] { "MaSP", "Size" });
            DropIndex("dbo.hoadons", new[] { "MaTK" });
            DropIndex("dbo.hoadons", new[] { "MaDH" });
            DropIndex("dbo.giohangs", new[] { "MaTK" });
            DropIndex("dbo.giohang_sanpham", new[] { "MaTP" });
            DropIndex("dbo.giohang_sanpham", new[] { "MaSP" });
            DropIndex("dbo.giohang_sanpham", new[] { "MaGH" });
            DropIndex("dbo.danhgias", new[] { "MaTK" });
            DropIndex("dbo.danhgias", new[] { "MaSP" });
            DropIndex("dbo.danhgias", new[] { "MaDH" });
            DropIndex("dbo.taikhoans", new[] { "MaLoaiTK" });
            DropIndex("dbo.donhangs", new[] { "MaTrangThai" });
            DropIndex("dbo.donhangs", new[] { "MaTK" });
            DropIndex("dbo.chitietdonhangs", new[] { "MaTP" });
            DropIndex("dbo.chitietdonhangs", new[] { "MaSP" });
            DropIndex("dbo.chitietdonhangs", new[] { "MaDH" });
            DropIndex("dbo.sanphams", new[] { "MaLoaiSP" });
            DropIndex("dbo.banggias", new[] { "MaSP" });
            DropTable("dbo.KhuyenMais");
            DropTable("dbo.hoadons");
            DropTable("dbo.giohangs");
            DropTable("dbo.giohang_sanpham");
            DropTable("dbo.danhgias");
            DropTable("dbo.toppings");
            DropTable("dbo.trangthaidonhangs");
            DropTable("dbo.LoaiTaiKhoans");
            DropTable("dbo.taikhoans");
            DropTable("dbo.donhangs");
            DropTable("dbo.chitietdonhangs");
            DropTable("dbo.loaisps");
            DropTable("dbo.sanphams");
            DropTable("dbo.banggias");
        }
    }
}
