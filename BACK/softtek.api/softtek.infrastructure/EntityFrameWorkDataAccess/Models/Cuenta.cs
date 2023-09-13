
namespace softtek.infrastructure.EntityFrameWorkDataAccess.Models
{
    public partial class Cuenta
    {
        public int Id { get; set; }
        public int? CuentaPadre { get; set; }
        public int? TipoCuentaId { get; set; }
        public virtual Tipo TipoCuenta { get; set; }
    }
}
