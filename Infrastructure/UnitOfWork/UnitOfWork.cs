using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Database;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            this.RoleContext = new RoleContext();
        }
        public RoleContext RoleContext { get; }

        public void Commit()
        {
            RoleContext?.SaveChanges();
        }

        public void Dispose()
        {
            RoleContext.Dispose();
        }
    }
}
