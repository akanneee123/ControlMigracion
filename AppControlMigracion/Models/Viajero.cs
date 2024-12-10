using System;
using System.Collections.Generic;

namespace AppControlMigracion.Models
{
    public class Viajero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Segundo { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string CorreoElectronico { get; set; }
        public string Genero { get; set; }

        // Relación uno a muchos con Documento
        public ICollection<Documento> Documentos { get; set; }

        // Relación uno a muchos con Movimiento
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}