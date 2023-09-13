using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softtek.infrastructure.EntityFrameWorkDataAccess.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string Cuenta { get; set; }
        public string NombreCuena { get; set; }
        public string Tercero { get; set; }
        public decimal? SaldoFinal { get; set; }
        public string? mensaje_naturaleza { get; set; }
        public string? mensaje_ajusteaceros { get; set; }
    }
}
