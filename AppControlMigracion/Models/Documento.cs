using System;

namespace AppControlMigracion.Models
{
    public class Documento
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaExpiracion { get; set; }

        // Clave foránea
        public int IdViajero { get; set; }
        public Viajero Viajero { get; set; } // Relación con Viajero
    }
}