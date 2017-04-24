﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Model.Dtos
{
   public  class RolesDto : EntityBase
    {
        /// <summary>
        /// 设置或获取角色名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 设置或获取角色编号
        /// </summary>
        public string No { set; get; }
    }
}
