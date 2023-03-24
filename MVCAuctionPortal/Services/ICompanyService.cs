using AuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services;

public interface ICompanyService
{
    int Create(Company dto);
    void Update(Company dto);
    int Delete(int id);
    Company GetCompanyById(int id);
    IEnumerable<Company> GetCompaniesForUser(int id);
    IEnumerable<Company> GetAllCompanies();
}