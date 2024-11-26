using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GongChaWebSale.Models
{
    public class LoaiTaiKhoan
    {
        [Key]
        public int MaLoaiTK { get; set; }
        public string TenLoai { get; set; }
    }
}