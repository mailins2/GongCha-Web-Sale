using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GongChaWebSale.Models
{
    public class trangthaidonhang
    {
        [Key] 
        public int MaTrangThai { get; set; }
        [StringLength(50)]
        public string TenTrangThai { get; set; }
    }
}