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
    public class OcupacionesController : Controller
    {
        private dbEventosEntities db = new dbEventosEntities();

        // GET: Ocupaciones
        public ActionResult Index()
        {
            var tbOcupaciones = db.tbOcupaciones.Include(t => t.tbUsuaios).Include(t => t.tbUsuaios1);
            return View(tbOcupaciones.ToList());
        }

        // GET: Ocupaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbOcupaciones tbOcupaciones = db.tbOcupaciones.Find(id);
            if (tbOcupaciones == null)
            {
                return HttpNotFound();
            }
            return View(tbOcupaciones);
        }

        // GET: Ocupaciones/Create
        public ActionResult Create()
        {
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario");
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario");
            return View();
        }

        // POST: Ocupaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ocu_Id,ocu_Descripcion,ocu_Estado,usu_UsuarioCreacion,ocu_FechaCreacion,usu_UsuarioModificacion,ocu_FechaModificacion")] tbOcupaciones tbOcupaciones)
        {
            if (ModelState.IsValid)
            {
                db.tbOcupaciones.Add(tbOcupaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbOcupaciones.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbOcupaciones.usu_UsuarioModificacion);
            return View(tbOcupaciones);
        }

        // GET: Ocupaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbOcupaciones tbOcupaciones = db.tbOcupaciones.Find(id);
            if (tbOcupaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbOcupaciones.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbOcupaciones.usu_UsuarioModificacion);
            return View(tbOcupaciones);
        }

        // POST: Ocupaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ocu_Id,ocu_Descripcion,ocu_Estado,usu_UsuarioCreacion,ocu_FechaCreacion,usu_UsuarioModificacion,ocu_FechaModificacion")] tbOcupaciones tbOcupaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbOcupaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbOcupaciones.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbOcupaciones.usu_UsuarioModificacion);
            return View(tbOcupaciones);
        }

        // GET: Ocupaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbOcupaciones tbOcupaciones = db.tbOcupaciones.Find(id);
            if (tbOcupaciones == null)
            {
                return HttpNotFound();
            }
            return View(tbOcupaciones);
        }

        // POST: Ocupaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbOcupaciones tbOcupaciones = db.tbOcupaciones.Find(id);
            db.tbOcupaciones.Remove(tbOcupaciones);
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
