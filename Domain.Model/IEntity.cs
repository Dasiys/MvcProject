using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    interface IEntity
    {
        int Id { get; set; }
    }
    public class EntityBase:IEntity
    {
        /// <summary>
        /// 设置或获取Id
        /// </summary>
        public int Id { set; get; }
    }
}
