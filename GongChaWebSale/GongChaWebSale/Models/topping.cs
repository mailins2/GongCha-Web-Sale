using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GongChaWebSale.Models
{
    public class topping
    {
        [Key] 
        public int MaTP { get; set; }
        [StringLength(int.MaxValue)] 
        public string TenTP { get; set; }
        [Required] 
        [Range(0, double.MaxValue, ErrorMessage = "Đơn giá phải lớn hơn hoặc bằng 0.")] 
        public decimal DonGia { get; set; }
        [StringLength(int.MaxValue)] 
        public string Hinh { get; set; }
    }
}