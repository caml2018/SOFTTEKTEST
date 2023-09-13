
using System.ComponentModel.DataAnnotations;

namespace softtek.infrastructure.EntityFrameWorkDataAccess.Models
{
    public partial class Report
    {
        [Key]
        public int Id { get; set; }
        public string Cuenta { get; set; }
        public string NombreCuena { get; set; }
        public string Tercero { get; set; }
        public decimal? SaldoInicial { get; set; }
        public decimal? SaldoFinal { get; set; }
        public decimal? Debito { get; set; }
        public decimal? Credito { get; set; }
        
    }
}
