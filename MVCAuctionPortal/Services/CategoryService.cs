using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServicesAndInterfacesLibary.Models;
using System.Collections.Generic;
using System.Linq;
using MVCAuctionPortal.Models;

namespace AuctionPortal.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AuctionDbContext _context;

        public CategoryService(AuctionDbContext context)
        {
            _context = context;
        }

        public int Create(Category dto)
        {
            _context.Category.Add(dto);
            _context.SaveChanges();
            return dto.CategoryID;
        }

        public int Delete(int id)
        {
            var category = _context.Category.Find(id);
            if (category != null)
            {
                _context.Category.Remove(category);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public void Update(Category dto)
        {
            _context.Category.Update(dto);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Category.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Category.Find(id);
        }
    }
}
