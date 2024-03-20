using Microsoft.EntityFrameworkCore;
using UnitTestAPI.Data;
using UnitTestAPI.Models;

namespace UnitTestAPI.Service
{
    public class CategoryService : IDisposable, ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                var category = await _context.Category.FindAsync(Id);
                if (category is null) return false;
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose() => _context?.Dispose();
           

        public async Task<Category?> GetCategory(Guid Id)
            => await _context.Category.FindAsync(Id);

        public async Task<List<Category>> GetCategory()
        => await _context.Category.ToListAsync();

        public async Task<bool> Save(Category category) 
        {
            try
            {
                category.CategoryId = Guid.NewGuid();
                _context.Category.Add(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Guid Id, Category category)
        {
            try
            {
                var cat = await _context.Category.FindAsync(Id);
                if (cat is null) return false;
                _context.Category.Attach(cat);
                cat.CategoryName = category.CategoryName;
                cat.Description = category.Description;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        Task<List<Category>> ICategoryService.GetCategory(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
