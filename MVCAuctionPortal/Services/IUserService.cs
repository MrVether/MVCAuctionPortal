using AuctionPortal.Models;
using AuctionPortal.Models.ViewModels;

namespace ServicesAndInterfacesLibary.Services;

public interface IUserService
{
    int Create(User user);
    void Update(User user);
    void Delete(int userId);
    User GetUserById(int userId);
    User GetUserByEmail(string email);
    IEnumerable<User> GetAllUsers();
    void UpdateUserProfile(UpdateUserViewModel model);
    UserDetailsViewModel GetUserDetails(int id);
}