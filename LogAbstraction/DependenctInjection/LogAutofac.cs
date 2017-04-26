using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace LogAbstraction.DependenctInjection
{
    public static class LogAutofac
    {
        public static ContainerBuilder LogOfInjection(this ContainerBuilder builder)
        {
            builder.RegisterType<CustomerLog>().As<ICustomerLog>().InstancePerLifetimeScope();
            return builder;
        }
    }
}
