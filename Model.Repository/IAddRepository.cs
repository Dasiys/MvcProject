using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public interface IAddRepository<in TEntity>
    {
        int Add(TEntity entity);
    }
}
