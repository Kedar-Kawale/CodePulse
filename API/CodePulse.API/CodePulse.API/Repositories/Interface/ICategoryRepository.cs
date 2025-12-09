using CodePulse.API.Models.Domain;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace CodePulse.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync(
            string? query = null , 
            string? sortBy=null , 
            string? sortDirection=null,
            int? pageNumber =1,
            int? pageSize = 100);  // here this could be any number according to requirement

        Task<Category?> GetById(Guid id);

        Task<Category?> UpdateAsync(Category category);  //the ? is nothing but a nullable category

        Task<Category?> DeleteAsync(Guid id);


        Task<int> GetCount();
    }
}
