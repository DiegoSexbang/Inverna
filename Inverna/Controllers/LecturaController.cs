using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inverna;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using GridMvc;


namespace Inverna.Controllers
{
    public class LecturaController : Controller
    {
        private BD db = new BD();
        


        public ActionResult Index()
        {
            Lectura let = new Lectura();
            List<Lectura> lista = let.lect();
            
            return View(lista);
        }



        



    }
}
