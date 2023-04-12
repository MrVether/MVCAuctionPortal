using AuctionPortal.Models;

namespace AuctionPortal.Services;

public interface IOrderService
{
    Task CreateOrderAsync(Order order, List<int> ints, List<int> auctionIds);
    Task<Order> GetOrderById(int id);
    Task UpdateOrderStatusAsync(int orderId, string newStatus, string paymentMethod);
    List<Order> GetOrdersByUserId(int userId);
    Order GetOrderDetailsById(int id);
}