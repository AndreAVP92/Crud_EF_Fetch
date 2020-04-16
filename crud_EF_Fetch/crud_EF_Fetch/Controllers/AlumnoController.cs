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
    }
}
