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
        private readonly ICommonMapper _commonMapper;
        private readonly IDataMapper _dataMapper;

        public DesignRepository()
        {
            _context = new HeadphonesDBContext();
            _commonMapper = new CommonMapper();
            _dataMapper = new DataMapper();
        }

        public DesignRepository(HeadphonesDBContext context, ICommonMapper commonMapper, IDataMapper dataMapper)
        {
            _context = context;
            _commonMapper = commonMapper;
            _dataMapper = dataMapper;
        }

        public bool Add(Design design)
        {
            throw new NotImplementedException();
        }

        public void Delete(Design design)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Design> GetAllDesigns()
        {
            var designs = new List<Design>();
            foreach(var des in _context.Designs)
            {
                var d = _commonMapper.ToDesign(des);
                designs.Add(d);
            }
            return designs;
        }
    }
}
