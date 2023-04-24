using Microsoft.EntityFrameworkCore;
using MVCAuctionPortal.Models;

namespace MVCAuctionPortal.Services
{
    public class BasketService : IBasketService
    {
        private readonly AuctionDbContext _context;

        public BasketService(AuctionDbContext context)
        {
            _context = context;
        }

        public async Task<bool> BasketExistsForUser(int userId)
        {
            return await _context.Basket.AnyAsync(b => b.UserID == userId).ConfigureAwait(false);
        }

        public async Task<Basket> CreateBasket(int userId)
        {
            if (await BasketExistsForUser(userId))
            {
                var existingBasket = await GetBasketByUserId(userId);
                return existingBasket;
            }

            var newBasket = new Basket
            {
                UserID = userId,
                NumberOfItems = 0,
                SummaryPrice = 0.0f
            };

            _context.Basket.Add(newBasket);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return newBasket;
        }

        public async Task<IEnumerable<Basket>> GetBaskets()
        {
            return await _context.Basket.Include(b => b.User).ToListAsync().ConfigureAwait(false);
        }

        public async Task<Basket> GetBasketByUserId(int userId)
        {
            var basket = await _context.Basket.AsNoTracking()
                .Include(b => b.BasketAndAuctions)
                .ThenInclude(ba => ba.Auction)
                .FirstOrDefaultAsync(b => b.UserID == userId)
                .ConfigureAwait(false);

            if (basket == null)
            {
                basket = await CreateBasket(userId);
            }

            return basket;
        }


        public async Task RemoveAuctionFromBasket(int userId, int auctionId)
        {
            var basket = await GetBasketByUserId(userId);
            if (basket != null)
            {
                var basketAuction = await _context.BasketAndAuctions
                    .FirstOrDefaultAsync(ba => ba.BasketId == basket.BasketID && ba.AuctionId == auctionId)
                    .ConfigureAwait(false);
                if (basketAuction != null)
                {
                    var auction = await _context.Auction.FindAsync(auctionId).ConfigureAwait(false);
                    if (auction != null)
                    {
                        basket.SummaryPrice -= (float)(basketAuction.Quantity * auction.Price);

                        _context.BasketAndAuctions.Remove(basketAuction);
                        await _context.SaveChangesAsync().ConfigureAwait(false);
                    }
                }
            }
        }



        public async Task UpdateAuctionQuantityInBasket(int userId, int auctionId, int quantity)
        {
            var basket = await GetBasketByUserId(userId);
            if (basket != null)
            {
                var basketAuction = await _context.BasketAndAuctions
                    .FirstOrDefaultAsync(ba => ba.BasketId == basket.BasketID && ba.AuctionId == auctionId)
                    .ConfigureAwait(false);
                if (basketAuction != null)
                {
                    var auction = await _context.Auction.FindAsync(auctionId).ConfigureAwait(false);
                    if (auction != null)
                    {
                        int oldQuantity = basketAuction.Quantity;
                        basketAuction.Quantity = quantity;

                        basket.NumberOfItems += (quantity - oldQuantity);
                        basket.SummaryPrice += (float)(auction.Price * (quantity - oldQuantity));

                        await _context.SaveChangesAsync().ConfigureAwait(false);
                    }
                }
            }
        }


        public async Task AddAuctionToBasket(int userId, int auctionId, int quantity)
        {
            var basket = await GetBasketByUserId(userId);
            var auction = await _context.Auction.FindAsync(auctionId).ConfigureAwait(false);

            if (basket == null || auction == null || quantity <= 0)
            {
                throw new ArgumentException("Invalid arguments.");
            }

            var basketAuction = await _context.BasketAndAuctions
                .FirstOrDefaultAsync(ba => ba.BasketId == basket.BasketID && ba.AuctionId == auctionId)
                .ConfigureAwait(false);

            if (basketAuction != null)
            {
                basketAuction.Quantity += quantity;
            }
            else
            {
                basketAuction = new BasketAndAuction
                {
                    BasketId = basket.BasketID,
                    AuctionId = auctionId,
                    Quantity = quantity,
                    Selected = true
                };

                _context.BasketAndAuctions.Add(basketAuction);
            }

            basket.NumberOfItems += quantity;
            basket.SummaryPrice += (float)(auction.Price * quantity);

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<Basket> GetBasketById(int id)
        {
            return await _context.Basket
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.BasketID == id)
                .ConfigureAwait(false);
        }

        public async Task<Basket> UpdateBasket(Basket basket)
        {
            _context.Entry(basket).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return basket;
        }

        public async Task<bool> DeleteBasket(int id)
        {
            var basket = await _context.Basket.FindAsync(id).ConfigureAwait(false);
            if (basket == null)
            {
                return false;
            }

            _context.Basket.Remove(basket);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }


        public bool BasketExists(int id)
        {
            return _context.Basket.Any(b => b.BasketID == id);
        }
    }
}