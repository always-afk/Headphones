using HeadphonesShop.DataAccess.Context;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.DataAccess.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HeadphonesDBContext _context;
        public IUsersRepository UsersRepository { get; }
        public ICompaniesRepository CompaniesRepository { get; }
        public IDesignRepository DesignRepository { get; }
        public IHeadphonesRepository HeadphonesRepository { get; }

        public UnitOfWork(HeadphonesDBContext context, IUsersRepository usersRepository, ICompaniesRepository companiesRepository, IDesignRepository designRepository, IHeadphonesRepository headphonesRepository)
        {
            _context = context;
            UsersRepository = usersRepository;
            CompaniesRepository = companiesRepository;
            DesignRepository = designRepository;
            HeadphonesRepository = headphonesRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
