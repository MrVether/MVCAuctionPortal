using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MVCAuctionPortal.Models;

namespace AuctionPortal.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly AuctionDbContext _context;

        public AuctionService(AuctionDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Auction> GetAllAuctions()
        {
            return _context.Auction
                .Include(a => a.Item)
                .Include(a => a.Category)
                .ToList();
        }

        public Auction GetAuctionById(int auctionId)
        {
            return _context.Auction
                .Include(a => a.Item)
                .Include(a => a.Category)
                .FirstOrDefault(a => a.AuctionID == auctionId);
        }

        public void AddAuction(Auction auction)
        {
            _context.Auction.Add(auction);
            _context.SaveChanges();
        }

        public void UpdateAuction(Auction dto)
        {
            var auction = _context.Auction.FirstOrDefault(a => a.AuctionID == dto.AuctionID);
            _context.Entry(dto).State = EntityState.Modified;
            _context.SaveChanges();
            
        }

        public void DeleteAuction(int auctionId)
        {
            var auction = _context.Auction.FirstOrDefault(a => a.AuctionID == auctionId);
            if (auction != null)
            {
                _context.Auction.Remove(auction);
                _context.SaveChanges();
            }
        }
    }
}
