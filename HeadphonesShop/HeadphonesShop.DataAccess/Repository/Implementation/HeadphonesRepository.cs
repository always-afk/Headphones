using HeadphonesShop.DataAccess.Models.LogicModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Models.DataModels;

namespace HeadphonesShop.DataAccess.Repository.Implementation
{
    public class HeadphonesRepository : Interfaces.IHeadphonesRepository
    {
        private Context.HeadphonesDBContext _context;

        public HeadphonesRepository(Context.HeadphonesDBContext context)
        {
            _context = context;
        }

        public bool TryAdd(HeadphonesModel headphones)
        {
            var head = new Models.DataModels.Headphone()
            {
                Name = headphones.Name,
                MaxFrequency = headphones.MaxFrequency,
                MinFrequency = headphones.MinFrequency,
                Picture = headphones.Picture,
                CompanyId = _context.Companies.Where(c => c.Name == headphones.Company.Name).Select(c => c.Id).Single(),
                DesignId = _context.Designs.Where(d => d.Name == headphones.Design.Name).Select(d => d.Id).Single()
            };

            if (_context.Headphones.Any(h => h.Name == head.Name))
            {
                return false;
            }

            _context.Headphones.Add(head);
            return true;

        }

        public void Delete(HeadphonesModel headphones)
        {
            var headphonesToDelete = _context.Headphones.First(h => h.Name == headphones.Name);
            _context.Headphones.Remove(headphonesToDelete);
        }

        public IEnumerable<HeadphonesModel> GetAllHeadphones()
        {
            var headphones = _context.Headphones.Select(h => new HeadphonesModel()
            {
                Name = h.Name,
                MinFrequency = h.MinFrequency,
                MaxFrequency = h.MaxFrequency,
                Picture = h.Picture,
                Company = new CompanyModel()
                {
                    Name = h.Company.Name
                },
                Design = new DesignModel()
                {
                    Name = h.Design.Name
                }
            }).ToList();

            return headphones;
        }

        public void Update(HeadphonesModel headphones)
        {
            var head = _context.Headphones.First(h => h.Name == headphones.Name);
            head.MinFrequency = headphones.MinFrequency;
            head.MaxFrequency = headphones.MaxFrequency;
            head.Picture = headphones.Picture;
            head.CompanyId = _context.Companies.First(c => c.Name == headphones.Company.Name).Id;
            head.DesignId = _context.Designs.First(d => d.Name == headphones.Design.Name).Id;
        }

        public HeadphonesModel GetHeadphonesByName(string name)
        {
            var head = _context.Headphones.Where(h => h.Name == name).Select(h => new HeadphonesModel()
            {
                Name = h.Name,
                MinFrequency = h.MinFrequency,
                MaxFrequency = h.MaxFrequency,
                Picture = h.Picture,
                Company = new CompanyModel()
                {
                    Name = h.Company.Name
                },
                Design = new DesignModel()
                {
                    Name = h.Design.Name
                }
            }).FirstOrDefault();

            return head;
        }

        public void DeleteByName(string name)
        {
            var headphonesToDelete = _context.Headphones.FirstOrDefault(h => h.Name == name);

            if (headphonesToDelete is null)
            {
                return;
            }

            _context.Headphones.Remove(headphonesToDelete);
        }

        public List<HeadphonesModel> GetFavoriteHeadphones(string userEmail)
        {
            var headphones = _context.UserHeadphones
                .Where(u => u.User.Login == userEmail)
                .Select(u => new HeadphonesModel()
                {
                    Name = u.Headphones.Name
                }).ToList();

            return headphones;
        }

        public void AddToFavorite(string userEmail, string headphonesName)
        {
            var userId = _context.Users.First(u => u.Login == userEmail).Id;
            var headphonesId = _context.Headphones.First(h => h.Name == headphonesName).Id;

            _context.UserHeadphones.Add(new UserHeadphone()
            {
                UserId = userId,
                HeadphonesId = headphonesId
            });
        }

        public void RemoveFromFavorite(string userEmail, string headphonesName)
        {
            var userId = _context.Users.First(u => u.Login == userEmail).Id;
            var headphonesId = _context.Headphones.First(h => h.Name == headphonesName).Id;
            var noteToDel = _context.UserHeadphones
                    .First(x => x.UserId == userId && x.HeadphonesId == headphonesId);
            _context.UserHeadphones.Remove(noteToDel);
        }

        public bool IsFavorite(string userEmail, string headphonesName)
        {
            var isFavorite = _context.UserHeadphones
                    .Any(x => x.User.Login == userEmail && x.Headphones.Name == headphonesName);
            return isFavorite;
        }
    }
}
