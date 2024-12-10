using System;

namespace AppControlMigracion.Models
{
    public class Auditoria
    {
        public int IdAuditoria { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaAccion { get; set; }
        public string Descripcion { get; set; }

        // Relación con Usuario
        public Usuario Usuario { get; set; }
    }
}