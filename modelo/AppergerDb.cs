using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst.Data
{
    public class appergerDb :DbContext
    {
      
        public DbSet<Imagen> imagenes { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Tratamiento> tratamientos { get; set; }
       
    }
}