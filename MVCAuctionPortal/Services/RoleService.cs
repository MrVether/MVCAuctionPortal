using Microsoft.AspNetCore.Identity;
using AuctionPortal.Models;
// ... inne using ...

public class RoleService : IRoleService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public RoleService(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task AssignRoleToUserAsync(int userId, int roleId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        var role = await _roleManager.FindByIdAsync(roleId.ToString());

        if (user == null || role == null)
        {
            throw new Exception("User or role not found.");
        }

        var result = await _userManager.AddToRoleAsync(user, role.Name);

        if (!result.Succeeded)
        {
            throw new Exception("Failed to assign role to user.");
        }
    }
}