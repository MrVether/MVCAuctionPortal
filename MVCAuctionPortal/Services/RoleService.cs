using AuctionPortal.Models;
using Microsoft.AspNetCore.Identity;
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

    public async Task AssignRoleToUserAsync(int userId, int roleId, bool isSeller = false)
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

        if (isSeller)
        {
            var sellerRole = await _roleManager.FindByIdAsync("3");
            if (sellerRole == null)
            {
                throw new Exception("Seller role not found.");
            }

            var sellerResult = await _userManager.AddToRoleAsync(user, sellerRole.Name);

            if (!sellerResult.Succeeded)
            {
                throw new Exception("Failed to assign seller role to user.");
            }
        }
    }

}