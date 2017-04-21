using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using Model.Repository.Permissions;

namespace Repository.Permissions
{
    public class PermissionsRepository:RepositoryBase<Domain.Model.Permissions>,IPermissionRepository
    {
        public PermissionsRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
