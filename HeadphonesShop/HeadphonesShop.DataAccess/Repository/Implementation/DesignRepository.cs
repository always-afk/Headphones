using HeadphonesShop.Common.Entities;
using HeadphonesShop.DataAccess.Context;
using HeadphonesShop.DataAccess.Services.Implementation;
using HeadphonesShop.DataAccess.Services.Interfaces;
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
        private readonly IMapper _mapper;

        //public DesignRepository()
        //{
        //    _context = new HeadphonesDBContext();
        //    _commonMapper = new CommonMapper();
        //    _dataMapper = new DataMapper();
        //}

        public DesignRepository(HeadphonesDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Add(Design design)
        {
            var dataDes = _mapper.ToDesign(design);
            if(!_context.Designs.Any(d => d.Name == dataDes.Name))
            {
                _context.Designs.Add(dataDes);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Design> GetAllDesigns()
        {
            var designs = new List<Design>();
            foreach(var des in _context.Designs)
            {
                var d = _mapper.ToDesign(des);
                designs.Add(d);
            }
            return designs;
        }

        public void Update(IEnumerable<Design> designs)
        {
            foreach(var design in _context.Designs)
            {
                if(!designs.Any(d => d.Name == design.Name))
                {
                    _context.Designs.Remove(design);
                }
            }
        }
    }
}
