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
    
    public partial class Emocion
    {
        public Emocion()
        {
            this.Selfie = new HashSet<Selfie>();
            this.Selfie1 = new HashSet<Selfie>();
        }
    
        public int nIdEmocion { get; set; }
        public string sDescripcion { get; set; }
    
        public virtual ICollection<Selfie> Selfie { get; set; }
        public virtual ICollection<Selfie> Selfie1 { get; set; }
    }
}
