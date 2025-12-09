namespace CodePulse.API.Models.Domain
{
    public class Category
    {
        public Guid Id  { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; }  //now this property represents the relationship between 'Category' and the 'BlogPost'
    }
}
