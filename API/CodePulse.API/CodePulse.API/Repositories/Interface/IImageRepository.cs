using CodePulse.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CodePulse.API.Repositories.Interface
{
    public interface IImageRepository
    {
          Task<BlogImage> Upload(IFormFile file, BlogImage blogImage);
          Task<IEnumerable<BlogImage>> GetAll();
          Task<BlogImage?> DeleteAsync(Guid id);
    }
}
