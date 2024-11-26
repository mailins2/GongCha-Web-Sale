using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GongChaWebSale.Models
{
    public class chitietdonhang
    {
        [Key, Column(Order = 1)] 
        public int MaDH { get; set; }
        [Key, Column(Order = 2)] 
        public int MaSP { get; set; }
        [Key, Column(Order = 3)] 
        [StringLength(1)] 
        public string Size { get; set; }
        [Key, Column(Order = 4)] 
        public int MaTP { get; set; }
        [Required] 
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn hoặc bằng 1.")] 
        public int SoLuong { get; set; } = 1;
        [Required] 
       
        public int ThuTu { get; set; } = 1;
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng tiền phải lớn hơn hoặc bằng 0.")]
        public decimal TongTienSP { get; set; } = 0;
        // Khóa ngoại
        public virtual donhang DonHang { get; set; } 
        public virtual sanpham SanPham { get; set; } 
        public virtual topping Topping { get; set; }
    }
}