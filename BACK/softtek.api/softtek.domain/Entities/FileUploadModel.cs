using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;

namespace softtek.domain.Entities
{
    public class FileUploadModel
    {
        public IFormFile FileDetails { get; set; }
    }
}
