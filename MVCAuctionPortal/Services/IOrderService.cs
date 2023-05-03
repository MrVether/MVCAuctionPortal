using AuctionPortal.Models;

namespace AuctionPortal.Services;

public interface IOrderService
{
    Task CreateOrderAsync(Order order, List<int> auctionIds, List<int> quantities, int userId, decimal discountPercentage);
    Task<Order> GetOrderById(int id);
    Task UpdateOrderStatusAsync(int orderId, string newStatus, string paymentMethod);
    List<Order> GetOrdersByUserId(int userId);
    Order GetOrderDetailsById(int id);
}