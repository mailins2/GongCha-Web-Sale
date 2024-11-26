using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GongChaWebSale.Models
{
    public class mydbcontext:DbContext
    {
        public mydbcontext() : base("MYCS") { }
        public DbSet <LoaiTaiKhoan> Loaitks { get; set; }
        public DbSet <taikhoan> Taikhoans { get; set; }
        public DbSet<loaisp> Loaisps { get; set; }

        public DbSet<sanpham> Sanphams { get; set; }
        public DbSet <banggia> Banggias { get; set; }
        public DbSet<topping> Toppings { get; set; }
        public DbSet <giohang> Giohangs { get; set; }
        public  DbSet<giohang_sanpham> giohang_Sanphams { get; set; }
        public DbSet<trangthaidonhang> Trangthaidonhangs { get; set; }
        public DbSet<donhang> Donhangs { get; set; }
        public DbSet <chitietdonhang> Chitietdonhangs { get; set; }
        public DbSet<hoadon> Hoadons { get; set; }
        public DbSet<danhgia> Danhgias { get; set; }
        public DbSet<KhuyenMai> khuyenMais {  get; set; }
    }
}