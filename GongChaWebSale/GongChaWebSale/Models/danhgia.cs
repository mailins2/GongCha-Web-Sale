using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GongChaWebSale.Models
{
    public class danhgia
    {
        [Key, Column(Order = 1)] 
        public int MaDH { get; set; }
        [Key, Column(Order = 2)] 
        public int MaSP { get; set; }
        [Required]
        public int MaTK { get; set; }
        [DataType(DataType.DateTime)] 
        public DateTime NgayDG { get; set; }
        [Required] 
        [Range(1, 5, ErrorMessage = "Số sao phải nằm trong khoảng từ 1 đến 5.")] 
        public int SoSao { get; set; } = 5; 
        public string NoiDung { get; set; } 
        // Khóa ngoại
        public virtual taikhoan TaiKhoan { get; set; }
        public virtual donhang DonHang { get; set; } 
        public virtual sanpham SanPham { get; set; }
    }
}