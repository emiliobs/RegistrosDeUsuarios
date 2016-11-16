using RegistrosDeUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RegistrosDeUsuarios.Controllers
{
    public class UsersController : Controller
    {

        SessionData session = new SessionData();

        UsersDatos usersDatos = new UsersDatos();
        // GET: User
        public ActionResult Users()
        {
            ViewBag.User = session.GetSession("userName");

            if (ViewBag.User == string.Empty)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {

                Caches();

                return View(usersDatos.UserDatos());
            }


        }

        public ActionResult Close()
        {
            session.DestruirSession();

            Caches();

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {


            ViewBag.User = session.GetSession("userName");


            Caches();
            return View(usersDatos.EditDatos(id));


        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserDatosModel model)
        {

            if (usersDatos.Actualizar(model) == true)
            {
                return RedirectToAction("Users");
            }
            else
            {
                Caches();
                return View(model);
            }

        }


        public ActionResult Details(int id)
        {
            ViewBag.User = session.GetSession("userName");

            if (ViewBag.User == String.Empty)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Caches();
                return View(usersDatos.EditDatos(id));
            }
        }

        public ActionResult Delete(int id)
        {
            ViewBag.User = session.GetSession("userName");

            if (ViewBag.User == string.Empty)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Caches();
                return View(usersDatos.EditDatos(id));
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Delete(UserDatosModel model)
        {
            if (usersDatos.Eliminar(model))
            {
                return RedirectToAction("Users");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Create()
        {
            ViewBag.User = session.GetSession("userName");

            if (ViewBag.User == String.Empty)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Caches();
                return View();
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Create(SingIn model)
        {
            if (ModelState.IsValid)
            {
                if (model.singIn() == false)
                {
                    ViewBag.Message = "El usuario o el email ya existen.";

                    return View("Create");
                }
                else
                {
                    return RedirectToAction("Users");
                }
            }

            return View("Create");
        }

        //borras los cahe dels navegador:
        public void Caches()
        {
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetNoStore();
        }


    }
}