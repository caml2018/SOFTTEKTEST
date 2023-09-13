using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using softtek.Application.Queries.Mayor;
using softtek.domain.Entities;
using System.Threading.Tasks;

namespace softtek.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformeResultadoController : ControllerBase
    {
        private readonly MayoryBalance _mayoryBalance;
        private readonly IGetMayoryBalance _getMayoryBalance;
        public InformeResultadoController(MayoryBalance mayoryBalance, IGetMayoryBalance getMayoryBalance)
        {
            _mayoryBalance = mayoryBalance;
            _getMayoryBalance = getMayoryBalance;
        }

        [HttpGet]

        //public IActionResult Get([FromQuery] PaginationFilter paginationFilter)
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(new { exito = 1, mensaje = "success", data = _mayoryBalance.getReport(await _getMayoryBalance.get()) });
            }
            catch (System.Exception ex)
            {

                return NotFound(new { exito=0,mensaje="error",data="ex" });
            }
            
        }
    }
}
