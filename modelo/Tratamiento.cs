using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CodeFirst.Data
{
    public class Tratamiento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int img_url { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public string Usuario_Doctor { get; set; }
        public string Usuario_Paciente { get; set; }
    }
}