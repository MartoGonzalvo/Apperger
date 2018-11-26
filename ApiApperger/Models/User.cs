using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiApperger.Models
{
    public class User
    {
        public int idUsuario { get; set; }
        public int rol { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public string matricula { get; set; }
        public DateTime fechaNac { get; set; }
        public string pais { get; set; }
        public string provincia { get; set; }
        public string ciudad { get; set; }
        public int nroPaciente { get; set; }
    }
}