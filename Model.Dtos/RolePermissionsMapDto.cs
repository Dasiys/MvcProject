﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Model.Dtos
{
    public class RolePermissionsMapDto:EntityBase
    {
        /// <summary>
        /// 设置或获取角色Id
        /// </summary>
        public int RoleId { set; get; }

        /// <summary>
        /// 设置或获取权限Id
        /// </summary>
        public int PermissionId { set; get; }
        /// <summary>
        /// 设置或获取父级Id
        /// </summary>
        public int ParentId { set; get; }
    }
}
