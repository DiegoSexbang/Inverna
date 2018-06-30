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
    public class UsuarioController : Controller
    {
        private BD db = new BD();

        // GET: Usuario
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.TipoUsuario);
            return View(usuario.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.tipousuario_idtipousuario = new SelectList(db.TipoUsuario, "idtipousuario", "nombre");
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idinforme,fecha,usuario_idtipousuario,tipolectura_idtipolectura,comentarios")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.tipousuario_idtipousuario = 1;   
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipousuario_idtipousuario = new SelectList(db.TipoUsuario, "idtipousuario", "nombre", usuario.tipousuario_idtipousuario);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipousuario_idtipousuario = new SelectList(db.TipoUsuario, "idtipousuario", "nombre", usuario.tipousuario_idtipousuario);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idusuario,nombreusuario,contrasenausuario,tipousuario_idtipousuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipousuario_idtipousuario = new SelectList(db.TipoUsuario, "idtipousuario", "nombre", usuario.tipousuario_idtipousuario);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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
