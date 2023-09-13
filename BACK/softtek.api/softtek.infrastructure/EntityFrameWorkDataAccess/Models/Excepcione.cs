using System;
using System.Collections.Generic;

#nullable disable

namespace softtek.infrastructure.EntityFrameWorkDataAccess.Models
{
    public partial class Excepcione
    {
        public int Id { get; set; }
        public int Cuenta { get; set; }
        public int? TipoCuentaId { get; set; }
        public string Tercero { get; set; }
        public decimal? ValorAjustePeso { get; set; }

        public virtual Tipo TipoCuenta { get; set; }
    }
}
