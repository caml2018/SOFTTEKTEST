using System;
using System.Collections.Generic;

#nullable disable

namespace softtek.infrastructure.EntityFrameWorkDataAccess.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Cuenta = new HashSet<Cuenta>();
            Excepciones = new HashSet<Excepcione>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Cuenta> Cuenta { get; set; }
        public virtual ICollection<Excepcione> Excepciones { get; set; }
    }
}
