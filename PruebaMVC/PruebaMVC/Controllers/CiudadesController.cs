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
    public class CiudadesController : Controller
    {
        private dbEventosEntities db = new dbEventosEntities();

        // GET: Ciudades
        public ActionResult Index()
        {
            var tbCiudades = db.tbCiudades.Include(t => t.tbUsuaios).Include(t => t.tbUsuaios1).Include(t => t.tbDepartamentos);
            return View(tbCiudades.ToList());
        }

        // GET: Ciudades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCiudades tbCiudades = db.tbCiudades.Find(id);
            if (tbCiudades == null)
            {
                return HttpNotFound();
            }
            return View(tbCiudades);
        }

        // GET: Ciudades/Create
        public ActionResult Create()
        {
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario");
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario");
            ViewBag.dep_Id = new SelectList(db.tbDepartamentos, "dep_Id", "dep_descripcion");
            return View();
        }

        // POST: Ciudades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ciu_Id,ciu_descripcion,dep_Id,ciu_Estado,usu_UsuarioCreacion,ciu_FechaCreacion,usu_UsuarioModificacion,ciu_FechaModificacion")] tbCiudades tbCiudades)
        {
            if (ModelState.IsValid)
            {
                db.tbCiudades.Add(tbCiudades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbCiudades.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbCiudades.usu_UsuarioModificacion);
            ViewBag.dep_Id = new SelectList(db.tbDepartamentos, "dep_Id", "dep_descripcion", tbCiudades.dep_Id);
            return View(tbCiudades);
        }

        // GET: Ciudades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCiudades tbCiudades = db.tbCiudades.Find(id);
            if (tbCiudades == null)
            {
                return HttpNotFound();
            }
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbCiudades.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbCiudades.usu_UsuarioModificacion);
            ViewBag.dep_Id = new SelectList(db.tbDepartamentos, "dep_Id", "dep_descripcion", tbCiudades.dep_Id);
            return View(tbCiudades);
        }

        // POST: Ciudades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ciu_Id,ciu_descripcion,dep_Id,ciu_Estado,usu_UsuarioCreacion,ciu_FechaCreacion,usu_UsuarioModificacion,ciu_FechaModificacion")] tbCiudades tbCiudades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbCiudades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbCiudades.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbCiudades.usu_UsuarioModificacion);
            ViewBag.dep_Id = new SelectList(db.tbDepartamentos, "dep_Id", "dep_descripcion", tbCiudades.dep_Id);
            return View(tbCiudades);
        }

        // GET: Ciudades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCiudades tbCiudades = db.tbCiudades.Find(id);
            if (tbCiudades == null)
            {
                return HttpNotFound();
            }
            return View(tbCiudades);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbCiudades tbCiudades = db.tbCiudades.Find(id);
            db.tbCiudades.Remove(tbCiudades);
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
