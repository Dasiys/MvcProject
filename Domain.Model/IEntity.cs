using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public interface IEntity
    {
        int Id { get; set; }
    }
    public class EntityBase:IEntity
    {
        /// <summary>
        /// 设置或获取Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
    }
}
