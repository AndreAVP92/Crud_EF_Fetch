using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crud_EF_Fetch.Models.ViewModel
{
    public class ListAlumnoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}