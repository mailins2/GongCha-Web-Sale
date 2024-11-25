using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using GongChaWebSale.Models;
namespace GongChaWebSale.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Database1Entities3 db = new Database1Entities3();
            //List<khuyenmai> khuyenmais = db.khuyenmai.ToList();
            return View();
        }
    }
}