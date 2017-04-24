using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Add
{
    public class PermissionsAddModel
    {
        /// <summary>
        /// 设置或获取权限名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 设置或获取是否为父级权限
        /// </summary>
        public int IsParent { set; get; }

        /// <summary>
        /// 设置或获取父级Id
        /// </summary>
        public int ParentId { set; get; }
    }
}
