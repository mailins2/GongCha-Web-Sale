using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GongChaWebSale.Models
{
    public class giohang_sanpham
    {
        [Key, Column(Order = 1)] 
        public int MaGH { get; set; }
        [Key, Column(Order = 2)] 
        public int MaSP { get; set; }
        [Key, Column(Order = 3)] 
        [StringLength(1)] 
        [RegularExpression("M|L", ErrorMessage = "Size phải là 'M' hoặc 'L'.")] 
        public string Size { get; set; }
        [Range(0, 100, ErrorMessage = "Mức đường phải nằm trong khoảng từ 0 đến 100.")] 
        public int? Duong { get; set; }
        [Range(0, 100, ErrorMessage = "Mức đá phải nằm trong khoảng từ 0 đến 100.")] 
        public int? Da { get; set; }
        [Required] 
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn hoặc bằng 1.")] 
        public int SoLuong { get; set; } = 1;
        [Required] 
        [Range(0, double.MaxValue, ErrorMessage = "Tổng tiền phải lớn hơn hoặc bằng 0.")] 
        public decimal TongTienSP { get; set; }
        [Key, Column(Order = 4)] 
        public int MaTP { get; set; }
        // Khóa ngoại
        public virtual giohang GioHang { get; set; } 
        public virtual sanpham SanPham { get; set; } 
        public virtual topping Topping { get; set; }
    }
}