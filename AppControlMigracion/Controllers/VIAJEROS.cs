//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppControlMigracion.Controllers
{
    using System;
    using System.Collections.Generic;
    
    public partial class VIAJEROS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VIAJEROS()
        {
            this.DOCUMENTO = new HashSet<DOCUMENTO>();
            this.MOVIMIENTO = new HashSet<MOVIMIENTO>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string segundo { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public System.DateTime fechaNacimiento { get; set; }
        public string nacionalidad { get; set; }
        public string correoElectronico { get; set; }
        public string genero { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTO> DOCUMENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMIENTO> MOVIMIENTO { get; set; }
    }
}
