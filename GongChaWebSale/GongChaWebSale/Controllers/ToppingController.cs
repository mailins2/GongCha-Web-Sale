using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GongChaWebSale.Models;
namespace GongChaWebSale.Controllers
{
    public class ToppingController : Controller
    {
        // GET: Topping
        public ActionResult Index()
        {
            mydbcontext db = new mydbcontext();
            List<topping> topping = db.Toppings.ToList();
            return View(topping);
        }
        public ActionResult Details(int id)
        {
            mydbcontext db = new mydbcontext();
            topping tp = db.Toppings.Where(row => row.MaTP == id).FirstOrDefault();
            return View(tp);
        }

    }
}