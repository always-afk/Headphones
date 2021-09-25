using HeadphonesShop.Common.Entities;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using HeadphonesShop.DataAccess.Services.Implementation;
using HeadphonesShop.DataAccess.Services.Interfaces;
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
        private IMapper _mapper;
        //public HeadphonesRepository()
        //{
        //    _context = new Context.HeadphonesDBContext();
        //    _dataMapper = new DataMapper();
        //    _commonMapper = new CommonMapper();
        //}

        public HeadphonesRepository(Context.HeadphonesDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Add(Headphones headphones)
        {
            var head = _mapper.ToHeadphones(headphones);
            head = Fill(head);
            if(!_context.Headphones.Any(h => h.Name == head.Name))
            {
                _context.Headphones.Add(head);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(Headphones headphones)
        {
            var headphonesToDel = _context.Headphones.Where(h => h.Name == headphones.Name).FirstOrDefault();
            _context.Headphones.Remove(headphonesToDel);
        }

        public IEnumerable<Headphones> GetAllHeadphones()
        {
            var headphones = new List<Headphones>();
            foreach(var h in _context.Headphones.Include(x => x.Design).Include(x => x.Company))
            {
                var head = _mapper.ToHeadphones(h);
                headphones.Add(head);
            }
            return headphones;
        }

        public void Update(Headphones headphones)
        {
            var head = _context.Headphones.Where(h => h.Name == headphones.Name).FirstOrDefault();
            head.MinFrequency = headphones.MinFrequency;
            head.MaxFrequency = headphones.MaxFrequency;
            head.CompanyId = _context.Companies.Where(c => c.Name == headphones.Company.Name).FirstOrDefault().Id;
            head.DesignId = _context.Designs.Where(d => d.Name == headphones.Design.Name).FirstOrDefault().Id;
        }

        private Models.Headphone Fill(Models.Headphone headphone)
        {
            headphone.CompanyId = _context.Companies.Where(c => c.Name == headphone.Company.Name).FirstOrDefault().Id;
            headphone.Company = null;
            headphone.DesignId = _context.Designs.Where(d => d.Name == headphone.Design.Name).FirstOrDefault().Id;
            headphone.Design = null;
            return headphone;
        }
    }
}
