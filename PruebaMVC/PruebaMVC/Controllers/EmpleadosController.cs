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
    public class EmpleadosController : Controller
    {
        private dbEventosEntities db = new dbEventosEntities();

        // GET: Empleados
        public ActionResult Index()
        {
            var tbEmpleados = db.tbEmpleados.Include(t => t.tbCiudades).Include(t => t.tbOcupaciones).Include(t => t.tbEstadosCiviles).Include(t => t.tbUsuaios).Include(t => t.tbUsuaios1);
            return View(tbEmpleados.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
            if (tbEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tbEmpleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.ciu_Id = new SelectList(db.tbCiudades, "ciu_Id", "ciu_descripcion");
            ViewBag.ocu_Id = new SelectList(db.tbOcupaciones, "ocu_Id", "ocu_Descripcion");
            ViewBag.estad_Id = new SelectList(db.tbEstadosCiviles, "estad_Id", "estad_descripcion");
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario");
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario");
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emp_Id,emp_PrimerNombre,emp_SegundoNombre,emp_PrimerApellido,emp_SegundoApellido,emp_Sexo,emp_FechaNacimiento,estad_Id,ciu_Id,emp_Direccion,emp_Telefono,ocu_Id,emp_Estado,usu_UsuarioCreacion,emp_FechaCreacion,usu_UsuarioModificacion,emp_FechaModificacion")] tbEmpleados tbEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.tbEmpleados.Add(tbEmpleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ciu_Id = new SelectList(db.tbCiudades, "ciu_Id", "ciu_descripcion", tbEmpleados.ciu_Id);
            ViewBag.ocu_Id = new SelectList(db.tbOcupaciones, "ocu_Id", "ocu_Descripcion", tbEmpleados.ocu_Id);
            ViewBag.estad_Id = new SelectList(db.tbEstadosCiviles, "estad_Id", "estad_descripcion", tbEmpleados.estad_Id);
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbEmpleados.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbEmpleados.usu_UsuarioModificacion);
            return View(tbEmpleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
            if (tbEmpleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.ciu_Id = new SelectList(db.tbCiudades, "ciu_Id", "ciu_descripcion", tbEmpleados.ciu_Id);
            ViewBag.ocu_Id = new SelectList(db.tbOcupaciones, "ocu_Id", "ocu_Descripcion", tbEmpleados.ocu_Id);
            ViewBag.estad_Id = new SelectList(db.tbEstadosCiviles, "estad_Id", "estad_descripcion", tbEmpleados.estad_Id);
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbEmpleados.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbEmpleados.usu_UsuarioModificacion);
            return View(tbEmpleados);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emp_Id,emp_PrimerNombre,emp_SegundoNombre,emp_PrimerApellido,emp_SegundoApellido,emp_Sexo,emp_FechaNacimiento,estad_Id,ciu_Id,emp_Direccion,emp_Telefono,ocu_Id,emp_Estado,usu_UsuarioCreacion,emp_FechaCreacion,usu_UsuarioModificacion,emp_FechaModificacion")] tbEmpleados tbEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbEmpleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ciu_Id = new SelectList(db.tbCiudades, "ciu_Id", "ciu_descripcion", tbEmpleados.ciu_Id);
            ViewBag.ocu_Id = new SelectList(db.tbOcupaciones, "ocu_Id", "ocu_Descripcion", tbEmpleados.ocu_Id);
            ViewBag.estad_Id = new SelectList(db.tbEstadosCiviles, "estad_Id", "estad_descripcion", tbEmpleados.estad_Id);
            ViewBag.usu_UsuarioCreacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbEmpleados.usu_UsuarioCreacion);
            ViewBag.usu_UsuarioModificacion = new SelectList(db.tbUsuaios, "usu_Id", "usu_Usuario", tbEmpleados.usu_UsuarioModificacion);
            return View(tbEmpleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
            if (tbEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tbEmpleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
            db.tbEmpleados.Remove(tbEmpleados);
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
