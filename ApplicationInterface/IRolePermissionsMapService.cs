using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace ApplicationInterface
{
    public interface IRolePermissionsMapService
    {
        IList<RolePermissionsMap> Fetch();
        void Delete(int Id);
        void Add(RolePermissionsMap permissions);
    }
}
