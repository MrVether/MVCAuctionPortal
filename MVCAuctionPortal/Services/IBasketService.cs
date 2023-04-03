using AuctionPortal.Models;
using MVCAuctionPortal.Models;

public interface IBasketService
{
    Task<Basket> CreateBasket(int userId);
    Task<IEnumerable<Basket>> GetBaskets();
    Task<Basket> GetBasketById(int id);
    Task<Basket> UpdateBasket(Basket basket);
    Task<Basket> GetBasketByUserId(int userId);
    Task<bool> DeleteBasket(int id);
    bool BasketExists(int id);
    Task AddAuctionToBasket(int userId, int auctionId, int quantity);
    Task UpdateAuctionQuantityInBasket(int userId, int auctionId, int quantity);
    Task RemoveAuctionFromBasket(int userId, int auctionId);

}