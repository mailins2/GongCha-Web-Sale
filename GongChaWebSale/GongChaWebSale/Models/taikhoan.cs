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
        [Required] 
        [StringLength(50)] 
        public string TenTK { get; set; }
        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        [StringLength(1000, ErrorMessage = "Mật khẩu phải có độ dài từ 6 đến 20 ký tự.", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "Mật khẩu phải chứa ít nhất một chữ cái và một số.")]
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
        
        [StringLength(10, ErrorMessage = "Số điện thoại không được vượt quá 10 ký tự.")]
        public string SDT { get; set; }

        public string Hinh { get; set; }
        [Required] 
        public int MaLoaiTK { get; set; }
        public virtual LoaiTaiKhoan LoaiTaiKhoan { get; set; }
    }
}