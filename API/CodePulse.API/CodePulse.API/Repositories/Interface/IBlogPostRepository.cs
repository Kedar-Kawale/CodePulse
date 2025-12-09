using CodePulse.API.Models.Domain;

namespace CodePulse.API.Repositories.Interface
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost); // this is the Interface definition


        Task<IEnumerable<BlogPost>> GetAllAsync(); // this is the Interface definition

        Task<BlogPost?> GetByIdAsync(Guid id); // this is the Interface definition

        Task<BlogPost?> GetByUrlHandleAsync( string urlHanlde); // this is the Interface definition

        Task<BlogPost?> UpdateAsync(BlogPost blogPost); // this is the Interface definition

        Task<BlogPost?> DeleteAsync(Guid id);  // this is the Interface definition


    }
}
