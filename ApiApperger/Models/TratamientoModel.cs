using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiApperger.Models
{
    public class TratamientoModel
    {
        public int idTratamiento { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public bool selfie { get; set; }
        public bool imagen { get; set; }
        public bool video { get; set; }
        public int idPsicologo { get; set; }
        public int idPaciente { get; set; }
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
        public int idEmocion { get; set; }
        public string sImagen { get; set; }
    }
}