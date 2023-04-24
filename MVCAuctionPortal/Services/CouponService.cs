using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
                .Where(a => a.UserId == user.Id);
        }
        public async Task<bool> CreateUserCouponAsync(Coupon coupon, string userEmail)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            if (user == null)
            {
                return false;
            }

            coupon.UserId = user.Id;
            _context.Add(coupon);
            await _context.SaveChangesAsync();

            return true;
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