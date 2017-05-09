using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Add
{
    public class RoleEditModel
    {
        public  int Id { set; get; }

        /// <summary>
        /// 设置或获取权限Id
        /// </summary>
        public  List<string> PermissionIds { set; get; }
    }
}
