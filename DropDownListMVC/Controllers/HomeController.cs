using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DropDownListMVC.Models;

namespace DropDownListMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            UsersData users = new UsersData();



            return View(users);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Index(UsersData user)
        {
            var id = user.Id;

            Response.Write(id);

            return View("Index", user);
        }
    }
}