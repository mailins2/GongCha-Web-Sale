using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GongChaWebSale.Models
{
    public class hoadon
    {
        [Key] 
        public int MaHD { get; set; }
        [Required] 
        public int MaDH { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng tiền phải lớn hơn hoặc bằng 0.")]
        public decimal TongTien { get; set; } = 0;
        [Range(0, double.MaxValue, ErrorMessage = "Giảm giá phải lớn hơn hoặc bằng 0.")]
        public decimal GiamGia { get; set; } = 0;
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Thành tiền phải lớn hơn hoặc bằng 0.")]
        public decimal ThanhTien { get; set; } = 0;
        [Required] 
        public int MaTK { get; set; } 
        // Khóa ngoại
        public virtual donhang DonHang { get; set; } 
        public virtual taikhoan TaiKhoan { get; set; }
    }
}