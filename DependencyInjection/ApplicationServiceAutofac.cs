using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationInterface;
using Autofac;
using Re;

namespace DependencyInjection
{
    public static class ApplicationServiceAutofac
    {
        public static ContainerBuilder ApplicationInjection(this ContainerBuilder builder)
        {
            builder.RegisterType<PermissionsService>().As<IPermissionsService>().InstancePerLifetimeScope();
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<RolePermissionsMapService>().As<IRolePermissionsMapService>().InstancePerLifetimeScope();
            return builder;
        }
    }
}
