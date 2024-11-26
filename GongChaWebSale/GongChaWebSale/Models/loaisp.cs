using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GongChaWebSale.Models
{
    public class loaisp
    {

        [Key] 
        public int MaLoaiSP { get; set; }
        [StringLength(255)]
        public string TenLoaiSP { get; set; }
    }
}