
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CodeFirst.Data

{
    public class Usuario
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Documento { get; set; }
        public DateTime Fecha_nac { get; set; }
        public string Nombre_usuario { get; set; }
        public string password{ get; set; }
        public int tratamiento_Id { get; set; }
        public int Rol_Id { get; set; }

    }
}
