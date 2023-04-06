using AuctionPortal.Models;

namespace AuctionPortal.Services;

public interface IOrderService
{
    Task CreateOrderAsync(Order order, List<int> ints, List<int> auctionIds);
}