using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GongChaWebSale.Models
{
    public class sanpham
    {
        [Key] 
        public int MaSP { get; set; }
        [StringLength(int.MaxValue)] 
        public string TenSP { get; set; }
        public int MaLoaiSP { get; set; }
        [StringLength(int.MaxValue)] 
        public string Hinh { get; set; }
        [StringLength(int.MaxValue)] 
        public string MoTa { get; set; } 
        // Khóa ngoại
        public virtual loaisp LoaiSanPham { get; set; }
    }
}