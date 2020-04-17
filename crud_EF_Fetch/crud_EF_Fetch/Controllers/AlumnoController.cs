using crud_EF_Fetch.Models;
using crud_EF_Fetch.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

namespace crud_EF_Fetch.Controllers
{
    public class AlumnoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var list = new List<ListAlumnoViewModel>();
            using(var db = new Alumnos_DBEntities())
            {
                list =
                    (from d in db.Alumno
                     orderby d.Id descending
                     select new ListAlumnoViewModel
                     {
                         Id = d.Id,
                         Nombre = d.Nombre,
                         Apellido = d.Apellido,
                         Edad = d.Edad,
                         Sexo = d.Sexo,
                         FechaRegistro = d.FechaRegistro
                     }).ToList();
            }

            return View(list);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(AlumnoViewModel model)
        {
            try
            {
                using (var db = new Alumnos_DBEntities())
                {
                    var oAlumno = new Alumno();
                    oAlumno.Nombre = model.Nombre;
                    oAlumno.Apellido = model.Apellido;
                    oAlumno.Edad = model.Edad;
                    oAlumno.Sexo = model.Sexo;
                    oAlumno.FechaRegistro = model.FechaRegistro;

                    db.Alumno.Add(oAlumno);
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);             
            }
        }

        public ActionResult Edit(int Id)
        {
            AlumnoViewModel model = new AlumnoViewModel();
            using (var db = new Alumnos_DBEntities())
            {
                var oAlumno = db.Alumno.Find(Id);
                
                model.Nombre = oAlumno.Nombre;
                model.Apellido = oAlumno.Apellido;
                model.Edad = oAlumno.Edad;
                model.Sexo = oAlumno.Sexo;
                //model.FechaRegistro = oAlumno.FechaRegistro;
                model.Id = oAlumno.Id;

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(AlumnoViewModel model)
        {
            try
            {
                using (var db = new Alumnos_DBEntities())
                {
                    var oAlumno = db.Alumno.Find(model.Id);
                    oAlumno.Nombre = model.Nombre;
                    oAlumno.Apellido = model.Apellido;
                    oAlumno.Edad = model.Edad;
                    oAlumno.Sexo = model.Sexo;
                    //oAlumno.FechaRegistro = model.FechaRegistro;

                    db.Entry(oAlumno).State = System.Data.Entity.EntityState.Modified; //Me indica el EF que el Id de dicho registro ha sido editado
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Delete (int Id)
        {
            try
            {
                using (var db = new Alumnos_DBEntities())
                {
                    var oAlumno = db.Alumno.Find(Id);
                    db.Alumno.Remove(oAlumno);                   
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
