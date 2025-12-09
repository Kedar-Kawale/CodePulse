using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CodePulse.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> DeleteAsync(Guid id)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCategory is null)
            {
                return null;
            }
            dbContext.Categories.Remove(existingCategory);
            await dbContext.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(
            string? query = null,
            string? sortBy = null,
            string? sortDirection = null,
            int? pageNumber = 1,
            int? pageSize = 100)
        {
            // Query the database 
            var categories = dbContext.Categories.AsQueryable();

            // filtering
            if(string.IsNullOrWhiteSpace(query) == false)
            {
                categories = categories.Where(x => x.Name.Contains(query));
            }

            //sorting 
            if(string.IsNullOrWhiteSpace(sortBy) == false)
            {
                //sorting by 'Name'
                if(string.Equals(sortBy, "Name", StringComparison.OrdinalIgnoreCase))
                {
                    var isAsc = string.Equals(sortDirection, "asc", StringComparison.OrdinalIgnoreCase)
                        ? true : false;

                   categories =  isAsc ? categories.OrderBy(x => x.Name): categories.OrderByDescending(x => x.Name);
                }
                //sorting by 'URL', so by this we can sort by any number of columns , now here we sort by 'Name'
                if (string.Equals(sortBy, "URL", StringComparison.OrdinalIgnoreCase))
                {
                    var isAsc = string.Equals(sortDirection, "asc", StringComparison.OrdinalIgnoreCase)
                        ? true : false;

                    categories = isAsc ? categories.OrderBy(x => x.UrlHandle) : categories.OrderByDescending(x => x.UrlHandle);
                }
            }


            //pagination
            // pageNumber 1, pageSize is 5 => this means will skip 0 results then take 5 results [pages 1,2,3,4,5]
            // pageNumber 2, pageSize is 5 => this means will skip 5 results then take 5 results  [pages 6,7,8,9,10]
            //pageNumber  3 , pageSize is 5 => this means will skip 10 results then take 5 results  

            var skipkardeResults = (pageNumber - 1) * pageSize;

            categories = categories.Skip(skipkardeResults ?? 0).Take(pageSize ?? 100);


            return await categories.ToListAsync();
        }

        public async Task<Category?> GetById(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

       

        public async Task<Category?> UpdateAsync(Category category)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if(existingCategory != null)
            {
                dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await dbContext.SaveChangesAsync();
                return category;
            }
            return null;
        }


        public async Task<int> GetCount()
        {
            return await dbContext.Categories.CountAsync();  // this CountAsync() method will give us total count of categories presented in the 'categories' table from the DB

        }
    }
}
