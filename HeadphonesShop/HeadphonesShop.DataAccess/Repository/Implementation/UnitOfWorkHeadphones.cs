using HeadphonesShop.DataAccess.Repository.Interfaces;
using HeadphonesShop.DataAccess.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.DataAccess.Repository.Implementation
{
    public class UnitOfWorkHeadphones : Interfaces.IUnitOfWorkHeadphones
    {
        private readonly Context.HeadphonesDBContext _context;
        public UnitOfWorkHeadphones()
        {
            _context = new Context.HeadphonesDBContext();
            var dMapper = new DataMapper();
            var cMapper = new CommonMapper();
            CompaniesRepository = new CompaniesRepository(_context, cMapper, dMapper);
            DesignRepository = new DesignRepository(_context, cMapper, dMapper);
            HeadphonesRepository = new HeadphonesRepository(_context, cMapper, dMapper);
        }
        public ICompaniesRepository CompaniesRepository { get; set; }
        public IDesignRepository DesignRepository { get; set; }
        public IHeadphonesRepository HeadphonesRepository { get; set; }

        public void Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
