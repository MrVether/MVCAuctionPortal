﻿using AuctionPortal.Models;
using MVCAuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly AuctionDbContext _context;

        public SubCategoryService(AuctionDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SubCategory> GetAllSubCategories(int id)
        {
            var subcategories = _context.SubCategory.Where(sc => sc.CategoryID == id).ToList();
            return subcategories;
        }

        public IEnumerable<SubCategory> GetAllSubCategories()
        {
            var subcategories = _context.SubCategory.ToList();
            return subcategories;
        }

        public SubCategory GetSubCategoryById(int id)
        {
            return _context.SubCategory.SingleOrDefault(s => s.SubCategoryID == id);
        }

        public int Create(SubCategory subCategory)
        {
            _context.SubCategory.Add(subCategory);
            _context.SaveChanges();
            return subCategory.SubCategoryID;
        }

        public void Update(SubCategory dto)
        {
            var subCategory = _context.SubCategory.Find(dto.SubCategoryID);

            if (subCategory != null)
            {
                subCategory.Name = dto.Name ?? subCategory.Name;
                subCategory.CategoryID = dto.CategoryID ?? subCategory.CategoryID;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var subCategory = _context.SubCategory.Find(id);

            if (subCategory != null)
            {
                _context.SubCategory.Remove(subCategory);
                _context.SaveChanges();
            }
        }
    }
}
