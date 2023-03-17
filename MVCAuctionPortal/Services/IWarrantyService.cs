using AuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services;

public interface IWarrantyService
{
    int Create(Warranty warranty);
    void Update(Warranty warranty);
    void Delete(int warrantyId);
    Warranty GetWarrantyById(int warrantyId);
    IEnumerable<Warranty> GetAllWarranties();
}