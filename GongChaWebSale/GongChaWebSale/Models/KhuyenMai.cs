using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GongChaWebSale.Models
{
    public class KhuyenMai
    {
        [Key,Column(Order =1)]
        [Required]
        public string Makm { get; set; }
        [Key, Column(Order = 2)]
        [Required]
        public int MaSP { get; set; }
        [Key, Column(Order = 3)]
        [Required]
        [RegularExpression("M|L", ErrorMessage = "Size phải là 'M' hoặc 'L'.")]
        public string Size { get; set; } = "M";
        [Required]
        [Range(0, 1, ErrorMessage = "Phần trăm giảm không được lớn hơn 1")]
        public decimal Ptgiam { get; set; } = 0;
        public string Tenkm {  get; set; }
        public string Noidung {  get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime NgayBatDau { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Date("NgayBatDau", ErrorMessage = "Ngày kết thúc phải lớn hơn ngày bắt đầu.")]
        public DateTime NgayKetThuc { get; set; }
        public virtual sanpham Sanpham { get; set; }
        public virtual banggia Banggia { get; set; }
    }
}