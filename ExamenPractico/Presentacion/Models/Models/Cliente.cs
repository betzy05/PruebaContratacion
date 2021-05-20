using System;
using System.Collections.Generic;

#nullable disable

namespace Presentacion.Models.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            RelClienteTienda = new HashSet<RelClienteTiendum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<RelClienteTiendum> RelClienteTienda { get; set; }
    }
}
