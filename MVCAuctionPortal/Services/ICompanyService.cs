using AuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services;

public interface ICompanyService
{
    int Create(Company dto);
    void Update(Company dto);
    int Delete(int id);
    Company GetCompanyById(int id);
    Company GetCompanyByUserId(int id);
    IEnumerable<Company> GetAllCompanies();
}