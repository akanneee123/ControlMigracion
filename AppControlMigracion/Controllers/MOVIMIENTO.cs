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
    
    public partial class MOVIMIENTO
    {
        public int idMovimientoViajero { get; set; }
        public System.DateTime fecha { get; set; }
        public string destino { get; set; }
        public string origen { get; set; }
        public string tipoSolicitud { get; set; }
        public int idUsuario { get; set; }
        public int idEstado { get; set; }
        public int idViajero { get; set; }
    
        public virtual ESTADOS ESTADOS { get; set; }
        public virtual USUARIO USUARIO { get; set; }
        public virtual VIAJEROS VIAJEROS { get; set; }
    }
}
