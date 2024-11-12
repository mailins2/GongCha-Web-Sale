using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GongChaWebSale.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(string Email, string PassWord)
        {

            return View();
        }
        public ActionResult Register(string LastName, string FirstName, string PhoneNumber, string Email, string PassWord)
        {

            return View();
        }
    }
}