using System;
using System.Collections.Generic;

#nullable disable

namespace Datos.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
    }
}
