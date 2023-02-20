using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaMVC.Models;

namespace PruebaMVC.Controllers
{
    public class EstadosCivilesController : Controller
    {
        private dbEventosEntities db = new dbEventosEntities();

        // GET: EstadosCiviles
        public ActionResult Index()
        {
            var tbEstadosCiviles = db.tbEstadosCiviles.Include(t => t.tbUsuaios).Include(t => t.tbUsuaios1);
            return View(tbEstadosCiviles.ToList());
        }

        // GET: EstadosCiviles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstadosCiviles tbEstadosCiviles = db.tbEstadosCiviles.Find(id);
            if (tbEstadosCiviles == null)
            {
                return HttpNotFound();
            }
            return View(tbEstadosCiviles);
        }

        // GET: EstadosCiviles/Create
        public ActionResult Create()
        {
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario");
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario");
            return View();
        }

        // POST: EstadosCiviles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "estad_Id,estad_descripcion,estad_Estado,usu_UsuarioCreacion,estad_FechaCreacion,usu_UsuarioModificacion,estad_FechaModificacion")] tbEstadosCiviles tbEstadosCiviles)
        {
            if (ModelState.IsValid)
            {
                db.tbEstadosCiviles.Add(tbEstadosCiviles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbEstadosCiviles.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbEstadosCiviles.usu_UsuarioModificacion);
            return View(tbEstadosCiviles);
        }

        // GET: EstadosCiviles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstadosCiviles tbEstadosCiviles = db.tbEstadosCiviles.Find(id);
            if (tbEstadosCiviles == null)
            {
                return HttpNotFound();
            }
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbEstadosCiviles.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbEstadosCiviles.usu_UsuarioModificacion);
            return View(tbEstadosCiviles);
        }

        // POST: EstadosCiviles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "estad_Id,estad_descripcion,estad_Estado,usu_UsuarioCreacion,estad_FechaCreacion,usu_UsuarioModificacion,estad_FechaModificacion")] tbEstadosCiviles tbEstadosCiviles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbEstadosCiviles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbEstadosCiviles.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbEstadosCiviles.usu_UsuarioModificacion);
            return View(tbEstadosCiviles);
        }

        // GET: EstadosCiviles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstadosCiviles tbEstadosCiviles = db.tbEstadosCiviles.Find(id);
            if (tbEstadosCiviles == null)
            {
                return HttpNotFound();
            }
            return View(tbEstadosCiviles);
        }

        // POST: EstadosCiviles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbEstadosCiviles tbEstadosCiviles = db.tbEstadosCiviles.Find(id);
            db.tbEstadosCiviles.Remove(tbEstadosCiviles);
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
