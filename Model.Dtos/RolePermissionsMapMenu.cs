using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
    public class RolePermissionsMapMenu
    {
        public string Name { set; get; }

        public IList<RolePermissionsMapMenu> ChildMenu { set; get; }

        /// <summary>
        /// 设置或获取是否被选中
        /// </summary>
        public bool IsChecked { set; get; }

        public  int PermissionId { set; get; }
    }
}
