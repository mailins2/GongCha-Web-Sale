using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GongChaWebSale.Models
{
    public class donhang
    {
        [Key] 
        public int MaDH { get; set; }
        [DataType(DataType.DateTime)] 
        public DateTime TgDat { get; set; } = DateTime.Now;
        [Required] 
        public int MaTK { get; set; }
        public string GhiChu { get; set; }
        public int? MaTrangThai { get; set; }
        [Range(0, 1, ErrorMessage = "Giá trị của trường ThanhToan phải là 0 hoặc 1.")] 
        public int ThanhToan { get; set; } 
        // Khóa ngoại
        public virtual taikhoan TaiKhoan { get; set; } 
        public virtual trangthaidonhang TrangThaiDonHang { get; set; }
    }
}