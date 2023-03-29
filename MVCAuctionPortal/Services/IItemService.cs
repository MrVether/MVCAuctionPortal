using AuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services;

public interface IItemService
{
    int Create(Item item);
    int? Delete(int? id);
    void Update(Item item);
    IEnumerable<Item> GetAllItems();
    Item GetItemById(int? id);
}