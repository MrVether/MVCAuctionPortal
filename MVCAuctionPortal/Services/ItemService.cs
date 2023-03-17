using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using MVCAuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services
{
    public class ItemService : IItemService
    {
        private readonly AuctionDbContext _context;

        public ItemService(AuctionDbContext context)
        {
            _context = context;
        }

        public int Create(Item item)
        {
            _context.Item.Add(item);
            _context.SaveChanges();
            return item.ItemID;
        }

        public int Delete(int id)
        {
            var item = _context.Item.FirstOrDefault(x => x.ItemID == id);
            if (item != null)
            {
                _context.Item.Remove(item);
                _context.SaveChanges();
                return id;
            }
            return 0;
        }

        public void Update(Item item)
        {
            if (item == null)
            {
                return;
            }

            var dbItem = _context.Item.FirstOrDefault(x => x.ItemID == item.ItemID);
            if (dbItem != null)
            {
                dbItem.Name = item.Name ?? dbItem.Name;
                dbItem.Description = item.Description ?? dbItem.Description;
                dbItem.Manufacturer = item.Manufacturer ?? dbItem.Manufacturer;
                dbItem.Condition = item.Condition ?? dbItem.Condition;
                dbItem.Model = item.Model ?? dbItem.Model;
                dbItem.Other = item.Other ?? dbItem.Other;

                _context.SaveChanges();
            }
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Item;
        }

        public Item GetItemById(int id)
        {
            return _context.Item.FirstOrDefault(x => x.ItemID == id);
        }
    }
}
