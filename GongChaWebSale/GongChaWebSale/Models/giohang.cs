using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GongChaWebSale.Models
{
    public class giohang
    {
        [Key]
        public int MaGH { get; set; }
        [Required]
        public int MaTK { get; set; }
        [DataType(DataType.DateTime)] 
        public DateTime NgayTao { get; set; } = DateTime.Now;
        [Required] 
        [Range(0, double.MaxValue, ErrorMessage = "Tổng tiền phải lớn hơn hoặc bằng 0.")] 
        public decimal TongTien { get; set; } = 0; 
        public virtual taikhoan TaiKhoan { get; set; }
    }
}