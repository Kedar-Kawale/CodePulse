namespace CodePulse.API.Models.Domain
{
    public class BlogImage
    {
        public Guid Id { get; set; } // unique identifier that is 'Id'
        public required string FileName { get; set; }  //prop to store File name
        public required string FileExtension { get; set; } //prop to save FIle Extension
        public required string  Title { get; set; } // prop to store  the Title
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
