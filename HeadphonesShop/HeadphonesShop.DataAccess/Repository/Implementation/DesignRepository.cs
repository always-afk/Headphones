using HeadphonesShop.DataAccess.Models.LogicModels;
using HeadphonesShop.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.DataAccess.Repository.Implementation
{
    public class DesignRepository : Interfaces.IDesignRepository
    {
        private readonly HeadphonesDBContext _context;

        public DesignRepository(HeadphonesDBContext context)
        {
            _context = context;
        }

        public bool TryAdd(Design design)
        {            
            if(!_context.Designs.Any(d => d.Name == design.Name))
            {
                var dataDes = new Models.DataModels.Design()
                {
                    Name = design.Name
                };
                _context.Designs.Add(dataDes);
                return true;
            }
            return false;
        }

        public IEnumerable<Design> GetAllDesigns()
        {
            var designs = _context.Designs.Select(d => new Design()
            {
                Name = d.Name
            }).ToList();
            return designs;
        }

        public void Update(IEnumerable<Design> designs)
        {
            var des = _context.Designs.Where(d => !designs.Any(x => x.Name == d.Name));
            _context.Designs.RemoveRange(des);
        }
    }
}
