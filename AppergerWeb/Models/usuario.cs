//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppergerWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            this.Tratamiento = new HashSet<Tratamiento>();
            this.Tratamiento1 = new HashSet<Tratamiento>();
        }
    
        public int nIdUsuario { get; set; }
        public Nullable<int> nRol { get; set; }
        public string sUsuario { get; set; }
        public string sContraseña { get; set; }
        public string sNombre { get; set; }
        public string sApellido { get; set; }
        public Nullable<short> nEdad { get; set; }
        public Nullable<short> sMatricula { get; set; }
        public Nullable<System.DateTime> dFechaNacimiento { get; set; }
        public string sPais { get; set; }
        public string sProvincia { get; set; }
        public string sCiudad { get; set; }
        public Nullable<int> nPacienteDe { get; set; }
    
        public virtual Rol Rol { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tratamiento> Tratamiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tratamiento> Tratamiento1 { get; set; }
    }
}
