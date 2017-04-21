using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace ApplicationInterface
{
    public interface IPermissionsService:IApplicationService
    {
        IList<Permissions> Fetch();
        void Delete(int Id);
        void Add(Permissions permissions);
    }
}
