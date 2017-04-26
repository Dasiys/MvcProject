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
        void Create<T>();
        void Create(Type t);
        void Create(string name);
    }

    public class CustomerLog : ICustomerLog
    {
        public void Create<T>()
        {
            this.Create(typeof(T));
        }

        public void Create(Type t)
        {
            this.Create(t.Name);
        }

        public void Create(string name)
        {
            LogManager.GetLogger(name);
        }
    }
}
