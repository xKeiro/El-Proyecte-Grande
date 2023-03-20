using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        [ActionName("Upload")]
        public IActionResult UploadFile()
        {
            try
            {
                var postedFile = Request.Form.Files[0];
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages");
                if (postedFile.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(postedFile.ContentDisposition).FileName?.Trim('"');
                    if (fileName != null)
                    {
                        var finalPath = Path.Combine(uploadFolder, fileName);
                        using (var fileStream = new FileStream(finalPath, FileMode.Create))
                        {
                            postedFile.CopyTo(fileStream);
                        }
                        return Ok($"File is uploaded Successfully");
                    }
                    return BadRequest("The File name can not be null.");
                }
                else
                {
                    return BadRequest("The File is not received.");
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Some Error Occcured while uploading File {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ShowImage(string id)
        {
            string imagePath = $"/DRIVERS/CODECOOL/ADVANCE/0_TW/El-Proyecte-Grande/backend/UploadedImages/{id}.jpg";
            byte[] imageData = await System.IO.File.ReadAllBytesAsync(imagePath);
            return File(imageData, "image/jpeg");
        }
    }
}

