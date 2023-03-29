using MVCAuctionPortal.Models;

namespace AuctionPortal.Services;

public interface ICategoryService
{
    int Create(Category dto);
    int Delete(int id);
    void Update(Category dto);
    IEnumerable<Category> GetAllCategories();
    Category GetCategoryById(int id);
}