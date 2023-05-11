using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace backend.Controllers
{
    [Authorize(Roles = "Admin")]
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
                return StatusCode(500, $"Some Error Occurred while uploading File {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [OutputCache(Duration = 120)]
        public async Task<IActionResult> ShowImage(string id)
        {
            string imagePath = $"{Directory.GetCurrentDirectory()}/UploadedImages/{id}.jpg";
            byte[] imageData = await System.IO.File.ReadAllBytesAsync(imagePath);
            return File(imageData, "image/jpeg");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFile(int id)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages", $"{id}.jpg");

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                return Ok("File deleted successfully");
            }

            return NotFound();
        }
    }
}

