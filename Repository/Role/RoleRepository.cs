using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using Model.Repository.Role;

namespace Repository.Role
{
    public class RoleRepository:RepositoryBase<Domain.Model.Role>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork unitOfWork):base(unitOfWork) { }
    }
}
