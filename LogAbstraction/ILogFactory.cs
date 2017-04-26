using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LogAbstraction
{
  public interface ICustomerLog
    {
        ILogger Create<T>();
        ILogger Create(Type t);
        ILogger Create(string name);
    }

    public class CustomerLog : ICustomerLog
    {
        public ILogger Create<T>()
        {
            return this.Create(typeof(T));
        }

        public ILogger Create(Type t)
        {
          return  this.Create(t.Name);
        }

        public ILogger Create(string name)
        {
            return LogManager.GetLogger(name);
        }
    }
}
