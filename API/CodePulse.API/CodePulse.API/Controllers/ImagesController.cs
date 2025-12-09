using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;
        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        //GET:  {apibaseUrl}/api/images
        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            //call image repository to get all images
            var images = await imageRepository.GetAll();


            // convert Domain model to DTO
            var response = new List<BlogImageDTO>();
            foreach(var image in images)
            {
                response.Add(new BlogImageDTO
                {
                    Id = image.Id,
                    Title = image.Title,
                    DateCreated = image.DateCreated,
                    FileExtension = image.FileExtension,
                    FileName = image.FileName,
                    Url = image.Url
                });
            }
            return Ok(response);
        }



        //POST: {apibaseUrl}/api/images
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] AddBlogImageRequestDTO request)
        {
            ValidateFileUpload(request.File);
            if (ModelState.IsValid)
            {
                //Map DTO to Domain model
                var blogImage = new BlogImage
                {
                    FileExtension = Path.GetExtension(request.File.FileName).ToLower(),
                    FileName = request.FileName,
                    Title = request.Title,
                    DateCreated = DateTime.Now
                };


                 blogImage = await this.imageRepository.Upload(request.File, blogImage);

                //Map to response DTO
                var response = new BlogImageDTO
                {
                    Id = blogImage.Id,
                    Title = blogImage.Title,
                    DateCreated = blogImage.DateCreated,
                    FileExtension = blogImage.FileExtension,
                    FileName = blogImage.FileName,
                    Url = blogImage.Url
                };
                    return Ok(blogImage);
            }

            //if the 'if' statement does not work properly then will return a bad request
            return BadRequest(ModelState);
        }


        //DELETE: {apibaseUrl}/api/images/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteImage([FromRoute] Guid id)
        {
           var deletedImage = await imageRepository.DeleteAsync(id);

            if(deletedImage == null)
            {
                return NotFound();
            }
            return Ok(deletedImage);

        }


        private void ValidateFileUpload(IFormFile file)
        {
            //1st-validation for file type, 
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" }; 
            //if file extension is not correct then show error to user, 
           if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported file format");
            }

            //2nd-validation for file size, the 10485760 number corresponds to 10MB
            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File Size can not be more than 10MB");
                
            }
        }

    }
}
