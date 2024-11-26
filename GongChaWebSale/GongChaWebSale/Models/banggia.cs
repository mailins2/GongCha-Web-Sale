using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GongChaWebSale.Models
{
    public class banggia
    {
        [Key] 
        [Column(Order = 1)] 
        public int MaSP { get; set; }
        [Key]
        [Column(Order = 2)] 
        [StringLength(1)] 
        [RegularExpression("M|L", ErrorMessage = "Size phải là 'M' hoặc 'L'.")] 
        public string Size { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Đơn giá phải lớn hơn hoặc bằng 0.")] 
        public decimal DonGia { get; set; } 
        // Khóa ngoại
        public virtual sanpham SanPham { get; set; }
    }
}