using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Permissions:EntityBase
    {
        /// <summary>
        /// 设置或获取权限名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 设置或获取是否为父级权限
        /// </summary>
        public bool IsParent { set; get; }

        /// <summary>
        /// 设置或获取父级Id
        /// </summary>
        public int ParentId { set; get; }
    }
}
