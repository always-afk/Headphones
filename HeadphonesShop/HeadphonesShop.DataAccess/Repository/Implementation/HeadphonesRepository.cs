using HeadphonesShop.DataAccess.Models.LogicModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.DataAccess.Repository.Implementation
{
    public class HeadphonesRepository : Interfaces.IHeadphonesRepository
    {
        private Context.HeadphonesDBContext _context;

        public HeadphonesRepository(Context.HeadphonesDBContext context)
        {
            _context = context;
        }

        public bool TryAdd(Headphones headphones)
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
            if(!_context.Headphones.Any(h => h.Name == head.Name))
            {
                _context.Headphones.Add(head);
                return true;
            }
            return false;
        }

        public void Delete(Headphones headphones)
        {
            var headphonesToDel = _context.Headphones.Where(h => h.Name == headphones.Name).Single();
            _context.Headphones.Remove(headphonesToDel);
        }

        public IEnumerable<Headphones> GetAllHeadphones()
        {
            var headphones = _context.Headphones.Select(h => new Headphones()
            {
                Name = h.Name,
                MinFrequency = h.MinFrequency,
                MaxFrequency = h.MaxFrequency,
                Picture = h.Picture,
                Company = new Company()
                {
                    Name = h.Company.Name
                },
                Design = new Design()
                {
                    Name = h.Design.Name
                }
            }).ToList();
            return headphones;
        }

        public void Update(Headphones headphones)
        {
            var head = _context.Headphones.Where(h => h.Name == headphones.Name).FirstOrDefault();
            head.MinFrequency = headphones.MinFrequency;
            head.MaxFrequency = headphones.MaxFrequency;
            head.Picture = headphones.Picture;
            head.CompanyId = _context.Companies.Where(c => c.Name == headphones.Company.Name).FirstOrDefault().Id;
            head.DesignId = _context.Designs.Where(d => d.Name == headphones.Design.Name).FirstOrDefault().Id;
        }

        public Headphones GetHeadphonesByName(string name)
        {
            var head = _context.Headphones.Where(h => h.Name == name).Select(h => new Headphones()
            {
                Name = h.Name,
                MinFrequency = h.MinFrequency,
                MaxFrequency = h.MaxFrequency,
                Picture = h.Picture,
                Company = new Company()
                {
                    Name = h.Company.Name
                },
                Design = new Design()
                {
                    Name = h.Design.Name
                }
            }).FirstOrDefault();
            return head;
        }

        public void DeleteByName(string name)
        {
            var headToDel = _context.Headphones.Where(h => h.Name == name).FirstOrDefault();
            if(headToDel is not null)
            {
                _context.Headphones.Remove(headToDel);
            }
        }
    }
}
