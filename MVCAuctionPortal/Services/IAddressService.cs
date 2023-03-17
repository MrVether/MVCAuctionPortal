using AuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services;

public interface IAddressService
{
    int Create(Address dto);
    void Update(Address dto);
    int Delete(int id);
    Address GetAddressById(int id);
    IEnumerable<Address> GetAllAddresses();
    Address GetById(int id);
}