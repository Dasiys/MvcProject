using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Model.Repository.Permissions;
using Model.Repository.Role;
using Model.Repository.RolePermissionsMap;
using Repository.Permissions;
using Repository.Role;
using Repository.RolePermissionsMap;

namespace DAL.DependencyInjection
{
    public static class RepositoryAutofac
    {
        public static ContainerBuilder RepositoryInjection(this ContainerBuilder builder)
        {
            builder.RegisterType<PermissionsRepository>().As<IPermissionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RolePermissionsMapRepository>().As<IRolePermissionsMapRepository>().InstancePerLifetimeScope();
            return builder;
        }
    }
}
