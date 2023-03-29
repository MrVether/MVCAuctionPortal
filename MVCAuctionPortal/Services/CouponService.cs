using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using MVCAuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services
{
    public class CouponService : ICouponService
    {
        private readonly AuctionDbContext _context;

        public CouponService(AuctionDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Coupon> GetCouponsForUser(User user)
        {

            return _context.Coupon
                .Where(a => a.CouponID == user.CouponID);
        }

        public int Create(Coupon dto)
        {
            _context.Coupon.Add(dto);
            _context.SaveChanges();
            return dto.CouponID;
        }

        public int Delete(int id)
        {
            var coupon = _context.Coupon.Find(id);
            if (coupon == null)
            {
                return 0;
            }
            _context.Coupon.Remove(coupon);
            _context.SaveChanges();
            return 1;
        }

        public void Update(Coupon coupon)
        {
            _context.Entry(coupon).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Coupon> GetAllCoupons()
        {
            return _context.Coupon.ToList();
        }

        public Coupon GetCouponById(int id)
        {
            return _context.Coupon.Find(id);
        }
    }
}