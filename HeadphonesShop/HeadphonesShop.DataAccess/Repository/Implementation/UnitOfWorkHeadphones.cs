using HeadphonesShop.DataAccess.Context;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using HeadphonesShop.DataAccess.Services.Interfaces;
using HeadphonesShop.DataAccess.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.DataAccess.Repository.Implementation
{
    public class UnitOfWorkHeadphones : IUnitOfWorkHeadphones
    {
        private readonly HeadphonesDBContext _context;
        //public UnitOfWorkHeadphones()
        //{
        //    _context = new HeadphonesDBContext();
        //    var dMapper = new DataMapper();
        //    var cMapper = new CommonMapper();
        //    CompaniesRepository = new CompaniesRepository(_context, cMapper, dMapper);
        //    DesignRepository = new DesignRepository(_context, cMapper, dMapper);
        //    HeadphonesRepository = new HeadphonesRepository(_context, cMapper, dMapper);
        //}
        public UnitOfWorkHeadphones(HeadphonesDBContext context, ICompaniesRepository companiesRepository, IDesignRepository designRepository, IHeadphonesRepository headphonesRepository)
        {
            _context = context;
            CompaniesRepository = companiesRepository;
            DesignRepository = designRepository;
            HeadphonesRepository = headphonesRepository;
        }
        public ICompaniesRepository CompaniesRepository { get; }
        public IDesignRepository DesignRepository { get; }
        public IHeadphonesRepository HeadphonesRepository { get; }

        public void Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
