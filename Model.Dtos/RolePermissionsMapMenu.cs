using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
    public class RolePermissionsMapMenu
    {
        public string Name { set; get; }

        public IList<RolePermissionsMapMenu> ChildMenu { set; get; }
    }
}
