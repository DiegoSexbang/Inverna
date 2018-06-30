using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inverna;

namespace Inverna.Controllers
{
    public class InformeController : Controller
    {
        private BD db = new BD();

        // GET: Informe
        public ActionResult Index()
        {
            var informe = db.Informe.Include(i => i.TipoLectura).Include(i => i.Usuario);
            return View(informe.ToList());
        }

        // GET: Informe/Details/5
        public ActionResult Details(int? id)
        {
            Informe informe = db.Informe.Find(id);
            Lectura let = new Lectura();
            List<Lectura> lista = let.lect();
          //  lista = lista.Where(l => l.tipolectura_idtipolectura == l.informe.tipolectura_idtipolectura).Tolist();
            List<Lectura> filtrado = new List<Lectura>();
            foreach(Lectura lec in lista)
            {
                if (informe.tipolectura_idtipolectura == lec.tipolectura_idtipolectura)
                {
                   filtrado.Add(lec);
                }

            } 
            ViewBag.ListadoLecturas = filtrado;
            return View();
        }//lista = lista.Where(l => l.tipolectura_idlectura == l.Informe.tipolectura_idtipolectura).Tolist();

        // GET: Informe/Create
        public ActionResult Create()
        {
            ViewBag.tipolectura_idtipolectura = new SelectList(db.TipoLectura, "idtipolectura", "nombre");
            ViewBag.usuario_idusuario = new SelectList(db.Usuario, "idusuario", "nombreusuario");
            return View();
        }

        // POST: Informe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idinforme,fecha,usuario_idusuario,tipolectura_idtipolectura,comentarios")] Informe informe)
        {
            if (ModelState.IsValid)
            {
                db.Informe.Add(informe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipolectura_idtipolectura = new SelectList(db.TipoLectura, "idtipolectura", "nombre", informe.tipolectura_idtipolectura);
            ViewBag.usuario_idusuario = new SelectList(db.Usuario, "idusuario", "nombreusuario", informe.usuario_idusuario);
            return View(informe);
        }

        // GET: Informe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informe informe = db.Informe.Find(id);
            if (informe == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipolectura_idtipolectura = new SelectList(db.TipoLectura, "idtipolectura", "nombre", informe.tipolectura_idtipolectura);
            ViewBag.usuario_idusuario = new SelectList(db.Usuario, "idusuario", "nombreusuario", informe.usuario_idusuario);
            return View(informe);
        }

        // POST: Informe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idinforme,fecha,usuario_idusuario,tipolectura_idtipolectura,comentarios")] Informe informe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipolectura_idtipolectura = new SelectList(db.TipoLectura, "idtipolectura", "nombre", informe.tipolectura_idtipolectura);
            ViewBag.usuario_idusuario = new SelectList(db.Usuario, "idusuario", "nombreusuario", informe.usuario_idusuario);
            return View(informe);
        }

        // GET: Informe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informe informe = db.Informe.Find(id);
            if (informe == null)
            {
                return HttpNotFound();
            }
            return View(informe);
        }

        // POST: Informe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Informe informe = db.Informe.Find(id);
            db.Informe.Remove(informe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
