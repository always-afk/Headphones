using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.DataAccess.Repository.Interfaces
{
    public interface IUnitOfWorkHeadphones
    {
        public ICompaniesRepository CompaniesRepository { get; set; }
        public IDesignRepository DesignRepository { get; set; }
        public IHeadphonesRepository HeadphonesRepository { get; set; }

        void Save();
    }
}
