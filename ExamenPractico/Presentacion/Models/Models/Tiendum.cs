using System;
using System.Collections.Generic;

#nullable disable

namespace Presentacion.Models.Models
{
    public partial class Tiendum
    {
        public Tiendum()
        {
            RelClienteTienda = new HashSet<RelClienteTiendum>();
        }

        public int Id { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<RelClienteTiendum> RelClienteTienda { get; set; }
    }
}
