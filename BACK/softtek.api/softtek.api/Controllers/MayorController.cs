using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using softtek.Application.Commands.Mayor;
using softtek.Application.Queries.Mayor;
using softtek.domain.Entities;

namespace softtek.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MayorController : ControllerBase
    {
        private readonly MayoryBalance _mayoryBalance;
        private readonly IWriteMayoryBalance _writeMayoryBalance;
        private readonly IGetMayoryBalance _getMayoryBalance;

        public MayorController(
            MayoryBalance mayoryBalance,
            IWriteMayoryBalance writeMayoryBalance,
            IGetMayoryBalance getMayoryBalance)
        {
            _mayoryBalance = mayoryBalance;
            _writeMayoryBalance = writeMayoryBalance;
            _getMayoryBalance = getMayoryBalance;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_getMayoryBalance.get());
        }
        [HttpGet]
        [Route("id")]
        public IActionResult Get(int id)
        {
            return Ok(_getMayoryBalance.get(id));
        }

        [HttpPost]
        public IActionResult Add()
        {
            //[FromForm] FileUploadModel fileDetails
            FileUploadModel fileDetails = new FileUploadModel();
            fileDetails.FileDetails = Request.Form.Files[0];
            _writeMayoryBalance.Insert(_mayoryBalance.readXmlDocument(fileDetails));
            return Ok(fileDetails);
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                _writeMayoryBalance.Delete();
                return Ok();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
            
        }
    }
}
