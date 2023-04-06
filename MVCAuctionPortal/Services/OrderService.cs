using AuctionPortal.Data;
using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MVCAuctionPortal.Models;

namespace AuctionPortal.Services
{
    public class OrderService : IOrderService
    {
        private readonly AuctionDbContext _context;
        private readonly IAuctionService _auctionService;

        public OrderService(AuctionDbContext context,IAuctionService auctionService)
        {
            _context = context;
            _auctionService = auctionService;
        }

        public async Task CreateOrderAsync(Order order, List<int> auctionIds, List<int> quantities)
        {
            order.OrderDate = DateTime.Now;
            order.UserID = 2;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            for (int i = 0; i < auctionIds.Count; i++)
            {
                int auctionId = auctionIds[i];
                var auction = await _context.Auction.FindAsync(auctionId);
                bool quantitiesSubtract = await _auctionService.ModifyQuantity(auctionId, quantities[i]);

                if (quantitiesSubtract)
                {
                    if (auction == null)
                    {
                        throw new ArgumentException($"Auction with ID {auctionId} not found.");
                    }

                    var orderItem = new OrderItem
                    {
                        AuctionId = auctionId,
                        OrderId = order.OrderID,
                        Quantity = quantities[i]
                    };

                    _context.OrderItems.Add(orderItem);
                }
            }

            await _context.SaveChangesAsync();
        }



    }
}