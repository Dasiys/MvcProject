using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Infrastructure.UnitOfWork;

namespace DAL.DependencyInjection
{
    public static class UnitOfWorkAutofac
    {
        public static ContainerBuilder UnitOfWorkInjection(this ContainerBuilder builder)
        {
            builder.RegisterType<Infrastructure.UnitOfWork.UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            return builder;
        }
    }
}
