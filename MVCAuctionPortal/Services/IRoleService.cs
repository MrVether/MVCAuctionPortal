using AuctionPortal.Models;

namespace ServicesAndInterfacesLibrary.Services;

public interface IRoleService
{
    IEnumerable<Role> GetAllRoles();
    Role GetRoleById(int id);
    Role CreateRole(Role dto);
    void UpdateRole(Role dto);
    void DeleteRole(int id);
}