using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using MVCAuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services
{
    public class ReviewService : IReviewService
    {
        private readonly AuctionDbContext _context;

        public ReviewService(AuctionDbContext context)
        {
            _context = context;
        }

        public int Create(Review review)
        {
            _context.Review.Add(review);
            _context.SaveChanges();
            return review.ReviewID;
        }
        public List<Review> GetReviewsByAuctionId(int auctionId)
        {
            return _context.Review.Where(r => r.AuctionID == auctionId).ToList();
        }
        public void Update(Review review)
        {
            var existingReview = _context.Review.Find(review.ReviewID);
            if (existingReview != null)
            {
                _context.Entry(existingReview).CurrentValues.SetValues(review);
                _context.SaveChanges();
            }
        }

        public int Delete(int id)
        {
            var review = _context.Review.Find(id);
            if (review != null)
            {
                _context.Review.Remove(review);
                _context.SaveChanges();
                return id;
            }
            return -1;
        }

        public Review GetReviewById(int id)
        {
            return _context.Review.Find(id);
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _context.Review.ToList();
        }
    }
}
