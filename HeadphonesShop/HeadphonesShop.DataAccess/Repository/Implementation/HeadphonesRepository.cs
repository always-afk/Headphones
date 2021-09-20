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
        private IDataMapper _dataMapper;
        private ICommonMapper _commonMapper;
        public HeadphonesRepository()
        {
            _context = new Context.HeadphonesDBContext();
            _dataMapper = new DataMapper();
            _commonMapper = new CommonMapper();
        }

        public HeadphonesRepository(Context.HeadphonesDBContext context, ICommonMapper commonMapper, IDataMapper dataMapper)
        {
            _context = context;
            _commonMapper = commonMapper;
            _dataMapper = dataMapper;
        }

        public bool Add(Headphones headphones)
        {
            var head = _dataMapper.ToHeadphones(headphones);
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
            var head = _dataMapper.ToHeadphones(headphones);
            head = Fill(head);
            _context.Headphones.Remove(head);
        }

        public IEnumerable<Headphones> GetAllHeadphones()
        {
            var headphones = new List<Headphones>();
            foreach(var h in _context.Headphones.Include(x => x.Design).Include(x => x.Company))
            {
                var head = _commonMapper.ToHeadphones(h);
                headphones.Add(head);
            }
            return headphones;
        }

        public void Update(IEnumerable<Headphones> headphones)
        {
            //var dheads = new List<Models.Headphone>();
            //foreach (var head in headphones)
            //{
            //    var h = _dataMapper.ToHeadphones(head);
            //    h = Fill(h);
            //    dheads.Add(h);
            //}
            foreach (var dhead in _context.Headphones)
            {
                if(!headphones.Any(h => h.Name == dhead.Name))
                {
                    _context.Headphones.Remove(dhead);
                }
            }

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
