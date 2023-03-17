using AuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services;

public interface IReviewService
{
    int Create(Review review);
    void Update(Review review);
    int Delete(int id);
    Review GetReviewById(int id);
    IEnumerable<Review> GetAllReviews();
}