using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Model.Dtos
{
    public class RoleMenu : EntityBase
    {
        public string Name { set; get; }

        public string No { set; get; }

        public IList<RolePermissionsMapMenu> Menu { set; get; }
    }
}
