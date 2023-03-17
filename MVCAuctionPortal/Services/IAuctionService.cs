using AuctionPortal.Models;

namespace AuctionPortal.Services;

public interface IAuctionService
{
    IEnumerable<Auction> GetAllAuctions();
    Auction GetAuctionById(int auctionId);
    void AddAuction(Auction auction);
    void UpdateAuction(Auction dto);
    void DeleteAuction(int auctionId);
}