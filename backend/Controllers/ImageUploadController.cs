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
                // 1. get the file form the request
                var postedFile = Request.Form.Files[0];
                // 2. set the file uploaded folder
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages");
                // 3. check for the file length, if it is more than 0 the save it
                if (postedFile.Length > 0)
                {
                    // 3a. read the file name of the received file
                    var fileName = ContentDispositionHeaderValue.Parse(postedFile.ContentDisposition)
                        .FileName.Trim('"');
                    // 3b. save the file on Path
                    var finalPath = Path.Combine(uploadFolder, fileName);
                    using (var fileStream = new FileStream(finalPath, FileMode.Create))
                    {
                        postedFile.CopyTo(fileStream);
                    }
                    return Ok($"File is uploaded Successfully");
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

        [HttpGet("{id}")] public async Task<IActionResult> ShowImage(string id)
        {
            // Construct the path to the image file based on the ID.
            string imagePath = $"/DRIVERS/CODECOOL/ADVANCE/0_TW/El-Proyecte-Grande/backend/UploadedImages/{id}.jpg";
            // Read the image data from the file.
            byte[] imageData = await System.IO.File.ReadAllBytesAsync(imagePath);
            // Return the image data as a file stream result.
            return File(imageData, "image/jpeg");
        }
    }
}

