﻿using AuctionPortal.Models;

namespace AuctionPortal.Services;

public interface IAuctionService
{
    IEnumerable<Auction> GetAllAuctions();
    Auction GetAuctionById(int? auctionId);
    List<Auction> GetAuctionsForUser(int userId);
    IEnumerable<Auction> GetAuctionBySubCategory(int subCategoryId);
    void AddAuction(Auction auction);
    void UpdateAuction(Auction dto);
    void DeleteAuction(int? auctionId);
    Task<bool> ModifyQuantity(int auctionId, int quantity);
    Auction GetAuctionByItemId(int itemId);

}