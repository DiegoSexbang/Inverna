using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inverna.Controllers
{
    public class HomeController : Controller
    {
        private BD db = new BD(); 
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]

        public ActionResult Index(string usuarioLogin, string contraseñaLogin)
        {
            Usuario us = new Usuario();
            var nombre = usuarioLogin;
            var pass = contraseñaLogin;
            
            List<Usuario> user = db.Usuario.ToList();
            foreach(Usuario use in user )
            {
                while (use.nombreusuario == usuarioLogin)
                {
                    if (use.contrasenausuario == contraseñaLogin)
                    {
                        return RedirectToAction("About", "Home");
                    }

                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();

            
        }

        public ActionResult About()
        {
            Lectura let = new Lectura();
            List<Lectura> lis = new List<Lectura>();
            List<Lectura> las = new List<Lectura>();
            lis = let.lect();
            int ultima = lis.Count();
            if (ultima > 5)
            {
                int ultimamenos10 = ultima - 5;

                for (int i = ultimamenos10; i < ultima; i++)
                {
                    las.Add(lis.ElementAt(i));


                }
            }
            else{
               
                for (int i = 0; i < ultima; i++)
                {
                    las.Add(lis.ElementAt(i));

                }

            }
            ViewBag.Ultima = las;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CerrarSesion()
        {
            return RedirectToAction("Index", "Home");
        }

        
        
    }
}