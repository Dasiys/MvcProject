using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Model.Dtos;

namespace ApplicationInterface
{
    public interface IRolePermissionsMapService
    {
        IList<RolePermissionsMapDto> Fetch();
        void Delete(int Id);
        void Add(RolePermissionsMap permissions);
        IList<RolePermissionsMapDto> Query(Expression<Func<RolePermissionsMap, bool>> param);
        IList<RolePermissionsMapMenu> GetRolePermissionsMenu(Expression<Func<RolePermissionsMap, bool>> param);
        void DeleteByRoleId(int roleId);
    }
}
