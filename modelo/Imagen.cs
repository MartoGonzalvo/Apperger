
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CodeFirst.Data
{
    public class Imagen
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Usuario_Id { get; set; }
        public string emocion { get; set; }
    }
}