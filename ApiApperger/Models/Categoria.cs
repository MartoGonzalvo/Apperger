//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiApperger.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categoria
    {
        public Categoria()
        {
            this.Imagen = new HashSet<Imagen>();
            this.Video = new HashSet<Video>();
        }
    
        public int nIdCategoria { get; set; }
        public string sDescripcion { get; set; }
        public Nullable<int> nIdTratamiento { get; set; }
    
        public virtual Tratamiento Tratamiento { get; set; }
        public virtual ICollection<Imagen> Imagen { get; set; }
        public virtual ICollection<Video> Video { get; set; }
    }
}
