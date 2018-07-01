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


            ViewBag.TotalLectura = lista;
            return View();
        }

        [HttpPost]
        public JsonResult Filtrar(int id)
        {
            var listalectura = db.Lectura.ToList();
            if(id != 0 )
                listalectura = listalectura.Where(l => l.tipolectura_idtipolectura == id).ToList();
            List<Pico> lista = new List<Pico>();
            foreach(var lectura in listalectura)
            {
                Pico pico = new Pico();
                pico.Valor = lectura.valor;
                pico.Fecha = lectura.hora.ToString();
                pico.TipoLectura = lectura.TipoLectura.nombre;
                lista.Add(pico);
            }
            //var lista = JsonConvert.SerializeObject(listalectura, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
            return Json(lista);
        }

        public class Pico
        {
            public double Valor { get; set; }
            public string Fecha { get; set; }
            public string TipoLectura { get; set; }
        }



    }
}
