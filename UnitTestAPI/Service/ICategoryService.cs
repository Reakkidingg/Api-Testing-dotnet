using UnitTestAPI.Models;

namespace UnitTestAPI.Service
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategory();
        Task<List<Category>> GetCategory(Guid Id);
        Task<bool> Save(Category category);
        Task<bool> Update(Guid Id, Category category);
        Task<bool> Delete(Guid Id);
    }
}
