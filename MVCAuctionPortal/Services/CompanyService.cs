﻿using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using MVCAuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AuctionDbContext _context;

        public CompanyService(AuctionDbContext context)
        {
            _context = context;
        }

        public int Create(Company dto)
        {
            _context.Company.Add(dto);
            _context.SaveChanges();
            return dto.CompanyID;
        }

        public void Update(Company dto)
        {
            _context.Entry(dto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var company = _context.Company.Find(id);
            if (company == null)
            {
                return 0;
            }

            _context.Company.Remove(company);
            _context.SaveChanges();
            return 1;
        }

        public Company GetCompanyById(int id)
        {
            return _context.Company.FirstOrDefault(c => c.CompanyID == id);
        }
        public IEnumerable<Company> GetCompaniesForUser(int? id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return Enumerable.Empty<Company>();
            }

            var companies = _context.Company
                .Where(c => c.CompanyID == user.CompanyID)
                .ToList();

            return companies;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _context.Company.ToList();
        }
    }
}
