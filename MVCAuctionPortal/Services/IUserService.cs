using AuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services;

public interface IUserService
{
    int Create(User user);
    void Update(User user);
    void Delete(int userId);
    User GetUserById(int userId);
    User GetUserByEmail(string email);
    IEnumerable<User> GetAllUsers();
    User Authenticate(string email, string password);
}