using System.Collections.Generic;

namespace AppControlMigracion.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }

        // Relación uno a muchos con Movimiento
        public ICollection<Movimiento> Movimientos { get; set; }

        // Relación uno a muchos con Auditoria
        public ICollection<Auditoria> Auditorias { get; set; }
    }
}