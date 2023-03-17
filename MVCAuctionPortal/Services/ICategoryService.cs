using ServicesAndInterfacesLibary.Models;

namespace ServicesAndInterfacesLibary.Services;

public interface ICategoryService
{
    int Create(Category dto);
    int Delete(int id);
    void Update(Category dto);
    IEnumerable<Category> GetAllCategories();
    Category GetCategoryById(int id);
}