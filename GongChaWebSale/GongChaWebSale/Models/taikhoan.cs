using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GongChaWebSale.Models
{
    public class taikhoan
    {
        [Key] 
        public int MaTK { get; set; }
        [Required] [StringLength(10)] 
        public string TenTK { get; set; }
        [Required] [StringLength(20)] 
        public string MatKhau { get; set; }
        [StringLength(30)] 
        public string HoTen { get; set; }
        [DataType(DataType.Date)] 
        public DateTime? NgaySinh { get; set; }
        [StringLength(5)] 
        public string GioiTinh { get; set; } 
        [StringLength(100)] 
        public string DiaChi { get; set; } 
        [Required] 
        [EmailAddress]
        [StringLength(50)] 
        public string Email { get; set; } 
        [Required] 
        [StringLength(10)] 
        public string SDT { get; set; } 
        public string Hinh { get; set; }
        [Required] 
        public int MaLoaiTK { get; set; }
        public virtual LoaiTaiKhoan LoaiTaiKhoan { get; set; }
    }
}