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
    
    public partial class DOCUMENTO
    {
        public int id { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public System.DateTime fechaExpiracion { get; set; }
        public int idViajero { get; set; }
    
        public virtual VIAJEROS VIAJEROS { get; set; }
    }
}
