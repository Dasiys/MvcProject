using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using Model.Repository.RolePermissionsMap;

namespace Repository.RolePermissionsMap
{
    public class RolePermissionsMapRepository : RepositoryBase<Domain.Model.RolePermissionsMap>, IRolePermissionsMapRepository
    {
        public RolePermissionsMapRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
