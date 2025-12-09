namespace CodePulse.API.Models.DTO
{
    public class AddBlogImageRequestDTO
    {
        // Holds the file stream from the form
        public IFormFile File { get; set; }
        // Holds the text metadata from the form
        public required string FileName { get; set; }
        public required string Title { get; set; }
    }
}
