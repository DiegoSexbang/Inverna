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
            var listalectura = db.Lectura.Include("TipoLectura").ToList();
            List<Filtro> lista = new List<Filtro>();
            foreach (var lectura in listalectura)
            {
                Filtro filtro = new Filtro();
                filtro.Valor = lectura.valor;
                filtro.Fecha = lectura.hora.ToString();
                filtro.TipoLectura = lectura.TipoLectura.nombre;
                lista.Add(filtro);
            }

            ViewBag.TotalLectura = lista;
            return View();
        }

        [HttpPost]
        public JsonResult Filtrar(int id)
        {
            var listalectura = db.Lectura.Include("TipoLectura").ToList();
            if(id != 0 )
                listalectura = listalectura.Where(l => l.tipolectura_idtipolectura == id).ToList();
            List<Filtro> lista = new List<Filtro>();
            foreach(var lectura in listalectura)
            {
                Filtro filtro = new Filtro();
                filtro.Valor = lectura.valor;
                filtro.Fecha = lectura.hora.ToString();
                filtro.TipoLectura = lectura.TipoLectura.nombre;
                lista.Add(filtro);
            }
            //var lista = JsonConvert.SerializeObject(listalectura, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
            return Json(lista);
        }
        [HttpPost]
       public ActionResult Lala()
        {
            var data = db.Lectura.Include("TipoLectura").ToList();
            

            return Json(new {data = data }, JsonRequestBehavior.AllowGet);
        }
        

        public class Filtro
        {
            public double Valor { get; set; }
            public string Fecha { get; set; }
            public string TipoLectura { get; set; }
        }



    }
}
