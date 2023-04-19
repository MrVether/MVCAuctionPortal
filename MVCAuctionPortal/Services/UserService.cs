using AuctionPortal.Models;
using AuctionPortal.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCAuctionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesAndInterfacesLibary.Services
{
    public class UserService : IUserService
    {
        private readonly AuctionDbContext _context;

        public UserService(AuctionDbContext context)
        {
            _context = context;
        }

        public int Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int userId)
        {
            var user = _context.Users.Find(userId);

            if (user == null)
            {
                throw new ArgumentException($"User with ID '{userId}' not found.");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }


        public void UpdateUserProfile(UpdateUserViewModel model)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == model.UserID);

            if (user != null)
            {
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.Nip = model.Nip;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("User not found.");
            }
        }

        public UserDetailsViewModel GetUserDetails(int userId)
        {

            var user = _context.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return new UserDetailsViewModel
                {
                    UserID = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Nip = user.Nip,
                    RegistrationDate = user.RegistationDate
                };
            }
            else
            {
                throw new Exception("User not found.");
            }
        }
    }
}
