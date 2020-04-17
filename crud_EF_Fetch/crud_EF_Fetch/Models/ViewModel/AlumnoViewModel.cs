using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace crud_EF_Fetch.Models.ViewModel
{
    public class AlumnoViewModel
    {
        public int Id { get; set; }
        [DisplayName("Su Nombre")]
        public string Nombre { get; set; }
        [DisplayName("Su Apellido")]
        public string Apellido { get; set; }
        [DisplayName("Su Edad")]
        public int Edad { get; set; } // Con '?' permite null
        [DisplayName("Su Género u Orientación sexual")]
        public string Sexo { get; set; }
        [DisplayName("Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }
    }
}