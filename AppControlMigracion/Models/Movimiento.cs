using System;

namespace AppControlMigracion.Models
{
    public class Movimiento
    {
        public int IdMovimientoViajero { get; set; }
        public DateTime Fecha { get; set; }
        public string Destino { get; set; }
        public string Origen { get; set; }
        public string TipoSolicitud { get; set; }

        // Claves foráneas
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; } // Relación con Usuario

        public int IdEstado { get; set; }
        public Estado Estado { get; set; } // Relación con Estado

        public int IdViajero { get; set; }
        public Viajero Viajero { get; set; } // Relación con Viajero
    }
}