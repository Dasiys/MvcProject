using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Model.Add;
using Model.Dtos;

namespace ApplicationInterface
{
    public interface IRoleService:IApplicationService
    {
        IList<RolesDto> Fetch();
        void Delete(int id);
        int Add(Role permissions);
        void AddRoleAndMap(RoleAddModel model);

        IList<RoleMenu> GetMenu();

        RoleMenu GetEditMenu(int id);

        void EditRoleMap(RoleEditModel model);


    }
}
