public interface IRoleService
{
    Task AssignRoleToUserAsync(int userId, int roleId);
}