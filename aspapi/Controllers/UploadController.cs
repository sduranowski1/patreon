using aspapi.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace aspapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UploadController : ControllerBase
    {
        [HttpPost] //api/upload/uploadfile
        public IActionResult UploadFile(IFormFile file) {
            return Ok(new UploadHandler().Upload(file));
        }
    }
}