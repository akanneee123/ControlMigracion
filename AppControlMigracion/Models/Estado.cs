using System;
using System.Collections.Generic;

namespace AppControlMigracion.Models
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string Descripcion { get; set; }
        public string TipoEstado { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relación uno a muchos con Movimiento
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}