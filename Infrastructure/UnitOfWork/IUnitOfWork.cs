using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Database;

namespace Infrastructure.UnitOfWork
{
    public interface IAbortContext : IDisposable
    {

    }
    public interface IEfContext : IAbortContext
    {
        RoleContext RoleContext { get; } 
    }
    public interface IUnitOfWork:IEfContext
    {
        void Commit();

    }
}
