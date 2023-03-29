using AuctionPortal.Models;
using MVCAuctionPortal.Models;

namespace ServicesAndInterfacesLibrary.Services
{
    public class RoleService : IRoleService
    {

        private readonly AuctionDbContext _context;

        public RoleService(AuctionDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Role.ToList();
        }

        public Role GetRoleById(int id)
        {
            return _context.Role.Find(id);
        }

        public Role CreateRole(Role dto)
        {
            _context.Role.Add(dto);
            _context.SaveChanges();
            return dto;
        }

        public void UpdateRole(Role dto)
        {
            var role = GetRoleById(dto.RoleID);

            if (role == null)
            {
                throw new RoleNotFoundException();
            }

            _context.Entry(role).CurrentValues.SetValues(dto);
            _context.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            var role = GetRoleById(id);

            if (role == null)
            {
                throw new RoleNotFoundException();
            }

            _context.Role.Remove(role);
            _context.SaveChanges();
        }

        public class RoleNotFoundException : Exception
        {
            public RoleNotFoundException()
                : base("Role not found")
            {
            }
        }
    }
}
