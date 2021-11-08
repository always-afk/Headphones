using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Context;
using HeadphonesShop.DataAccess.Models.LogicModels;
using HeadphonesShop.DataAccess.Repository.Interfaces;

namespace HeadphonesShop.DataAccess.Repository.Implementation
{
    public class RolesRepository : IRolesRepository
    {
        private readonly HeadphonesDBContext _context;

        public RolesRepository(HeadphonesDBContext context)
        {
            _context = context;
        }

        public IEnumerable<RoleModel> GetRoles()
        {
            var res = _context.Roles.Select(r => new RoleModel()
            {
                Name = r.Name
            });

            return res;
        }
    }
}
