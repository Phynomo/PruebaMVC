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
    public class UsuaiosController : Controller
    {
        private dbEventosEntities db = new dbEventosEntities();

        // GET: Usuaios
        public ActionResult Index()
        {
            var tbUsuaios = db.tbUsuaios.Include(t => t.tbEmpleados2).Include(t => t.tbUsuaios2).Include(t => t.tbUsuaios3);
            return View(tbUsuaios.ToList());
        }

        // GET: Usuaios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuaios tbUsuaios = db.tbUsuaios.Find(id);
            if (tbUsuaios == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuaios);
        }

        // GET: Usuaios/Create
        public ActionResult Create()
        {
            ViewBag.emp_id = new SelectList(db.tbEmpleados, "emp_Id", "emp_PrimerNombre");
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario");
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario");
            return View();
        }

        // POST: Usuaios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usu_Id,usu_Usuario,usu_Password,usu_Admin,usu_Estado,usu_UsuarioCreacion,usu_FechaCreacion,usu_UsuarioModificacion,usu_FechaModificacion,emp_id")] tbUsuaios tbUsuaios)
        {
            if (ModelState.IsValid)
            {
                db.tbUsuaios.Add(tbUsuaios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.emp_id = new SelectList(db.tbEmpleados, "emp_Id", "emp_PrimerNombre", tbUsuaios.emp_id);
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbUsuaios.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbUsuaios.usu_UsuarioModificacion);
            return View(tbUsuaios);
        }

        // GET: Usuaios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuaios tbUsuaios = db.tbUsuaios.Find(id);
            if (tbUsuaios == null)
            {
                return HttpNotFound();
            }
            ViewBag.emp_id = new SelectList(db.tbEmpleados, "emp_Id", "emp_PrimerNombre", tbUsuaios.emp_id);
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbUsuaios.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbUsuaios.usu_UsuarioModificacion);
            return View(tbUsuaios);
        }

        // POST: Usuaios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usu_Id,usu_Usuario,usu_Password,usu_Admin,usu_Estado,usu_UsuarioCreacion,usu_FechaCreacion,usu_UsuarioModificacion,usu_FechaModificacion,emp_id")] tbUsuaios tbUsuaios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbUsuaios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.emp_id = new SelectList(db.tbEmpleados, "emp_Id", "emp_PrimerNombre", tbUsuaios.emp_id);
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbUsuaios.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbUsuaios.usu_UsuarioModificacion);
            return View(tbUsuaios);
        }

        // GET: Usuaios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuaios tbUsuaios = db.tbUsuaios.Find(id);
            if (tbUsuaios == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuaios);
        }

        // POST: Usuaios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbUsuaios tbUsuaios = db.tbUsuaios.Find(id);
            db.tbUsuaios.Remove(tbUsuaios);
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
