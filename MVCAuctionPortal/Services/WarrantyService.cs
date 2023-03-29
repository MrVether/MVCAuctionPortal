using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using MVCAuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services
{
    public class WarrantyService : IWarrantyService
    {
        private readonly AuctionDbContext _context;

        public WarrantyService(AuctionDbContext context)
        {
            _context = context;
        }

        public int Create(Warranty warranty)
        {
            _context.Warranty.Add(warranty);
            _context.SaveChanges();
            return warranty.WarrantyID;
        }

        public void Update(Warranty warranty)
        {
            _context.Warranty.Update(warranty);
            _context.SaveChanges();
        }

        public void Delete(int warrantyId)
        {
            var warranty = _context.Warranty.Find(warrantyId);
            if (warranty != null)
            {
                _context.Warranty.Remove(warranty);
                _context.SaveChanges();
            }
        }


        public Warranty GetWarrantyById(int warrantyId)
        {
            return _context.Warranty.Find(warrantyId);
        }

        public IEnumerable<Warranty> GetAllWarranties()
        {
            return _context.Warranty.ToList();
        }
    }
}