using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MVCAuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services
{
    public class AddressService : IAddressService
    {
        private readonly AuctionDbContext _context;

        public AddressService(AuctionDbContext context)
        {
            _context = context;
        }

        public int Create(Address dto)
        {
            _context.Address.Add(dto);
            _context.SaveChanges();
            return dto.AddressID;
        }

        public void Update(Address dto)
        {
            _context.Entry(dto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var address = _context.Address.Find(id);
            if (address == null)
            {
                return 0;
            }
            _context.Address.Remove(address);
            _context.SaveChanges();
            return 1;
        }

        public Address GetAddressById(int id)
        {
            return _context.Address.Find(id);
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            return _context.Address.ToList();
        }

        public Address GetById(int id)
        {
            return _context.Address.Find(id);
        }
    }
}