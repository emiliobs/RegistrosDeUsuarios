using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RegistrosDeUsuarios.Models;

namespace RegistrosDeUsuarios.Controllers
{
    public class HomeController : Controller
    {
        SessionData session = new SessionData();

        // GET: Home
        public ActionResult Index()
        {
            //aqui destruyo la session.!!!
           // session.DestruirSession();

            return View();
        }


        [HttpGet]
        public ActionResult Usuarios()
        {


            return  View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Usuarios(UserLogin datos)
        {

            if (ModelState.IsValid)
            {
                if (datos.Login() == true)
                {
                    session.SetSession("userName", datos.UserName);

                    ViewBag.User = session.GetSession("userName");

                    return RedirectToAction("Users","Users");
                }
                else
                {

                    ViewBag.Message = "Error";

                    return View("Index");
                }


            }
            else
            {
                return View("Index");
            }


        }

        public ActionResult SingIn()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SingIn(SingIn datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.singIn() == false)
                {
                    ViewBag.Message = "El usuario o Email ya estan registrados.";

                    return View("SingIn", datos);
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
            else
            {
                return View("SingIn");
            }
        }

    }
}