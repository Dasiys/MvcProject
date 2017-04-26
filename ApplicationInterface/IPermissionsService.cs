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
    public interface IPermissionsService:IApplicationService
    {
        IList<PermissionsDto> Fetch();
        void Delete(int Id);
        void Add(Permissions permissions);

        IList<PermissionsDto> Query(Expression<Func<Permissions, bool>> param);



        IList<PermissionsMenu> GetMenu(IList<PermissionsDto> permissionsDto, int parentId);
    }
}
