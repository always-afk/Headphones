using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.DataAccess.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public IUsersRepository UsersRepository { get; }
        public IRolesRepository RolesRepository { get; }
        public ICompaniesRepository CompaniesRepository { get; }
        public IDesignRepository DesignRepository { get; }
        public IHeadphonesRepository HeadphonesRepository { get; }
        public void Save();
    }
}
