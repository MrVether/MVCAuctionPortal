using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using MVCAuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AuctionDbContext _context;

        public CompanyService(AuctionDbContext context)
        {
            _context = context;
        }

        public int Create(Company dto)
        {
            _context.Company.Add(dto);
            _context.SaveChanges();
            return dto.CompanyID;
        }

        public void Update(Company dto)
        {
            _context.Entry(dto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var company = _context.Company.Find(id);
            if (company == null)
            {
                return 0;
            }

            _context.Company.Remove(company);
            _context.SaveChanges();
            return 1;
        }

        public Company GetCompanyById(int id)
        {
            return _context.Company.Include(c => c.CompanyAddress)
                                      .FirstOrDefault(c => c.CompanyID == id);
        }  
        public Company GetCompanyByUserId(int id)
        {
            var user=_context.User.Find(id);
            return _context.Company.Include(c => c.CompanyAddress)
                                      .FirstOrDefault(c => c.CompanyID == user.CompanyID);
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _context.Company.Include(c => c.CompanyAddress).ToList();
        }
    }
}
