﻿using AuctionPortal.Models;
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
                .Include(a => a.SubCategory)
                .ToList();
        }

        public Auction GetAuctionById(int auctionId)
        {
            return _context.Auction
                .Include(a => a.Item)
                .Include(a => a.SubCategory)
                .FirstOrDefault(a => a.AuctionID == auctionId);
        }
        public List<Auction> GetAuctionsForUser(int id)
        {
            var user = _context.User.Find(id);
            return _context.Auction.Where(c => c.UserID == user.UserID).ToList();
        }


        public IEnumerable<Auction> GetAuctionBySubCategory(int Id)
        {
            var auctionList = _context.Auction.Where(x => x.SubCategoryID == Id).Include(a => a.Item)
                .Include(a => a.SubCategory);
            return auctionList;

        }

        public void AddAuction(Auction auction)
        {
            auction.UserID = 2;
            auction.ReviewID = null;
            auction.DateOfIssue = DateTime.Now;
            _context.Auction.Add(auction);
            _context.SaveChanges();
        }

        public void UpdateAuction(Auction dto)
        {
            var auction = _context.Auction.FirstOrDefault(a => a.AuctionID == dto.AuctionID);
            var item = _context.Item.FirstOrDefault(a => a.ItemID == dto.ItemID);

            if (auction != null&& item!=null)
            {
                auction.Title = dto.Title;
                auction.BuyItNow = dto.BuyItNow;
                auction.EndDate = dto.EndDate;
                auction.Price = dto.Price;
                auction.Pieces = dto.Pieces;
                auction.SubCategoryID = dto.SubCategoryID;
                auction.ItemID = dto.ItemID;
                auction.WarrantyID = dto.WarrantyID;
                auction.ImageURL = dto.ImageURL;
                item.Description = dto.Item.Description;

            }
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
