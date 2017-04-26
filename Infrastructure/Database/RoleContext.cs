using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.Map;
using LogAbstraction;

namespace Infrastructure.Database
{
    public class RoleContext:DbContext
    {
        public RoleContext( ):base("name=default")
        {
        }
        static RoleContext()
        {
            DbInterception.Add(new OurInterception());
            System.Data.Entity.Database.SetInitializer<RoleContext>(null);
        }

        public DbSet<Role> Role { set; get; }
        public DbSet<Permissions> Permissions { set; get; }
        public DbSet<RolePermissionsMap> RolePermissionsMap { set; get; }

        protected override void OnModelCreating(DbModelBuilder modleBuilder)
        {
            modleBuilder.Configurations.Add(new RoleMap())
                                       .Add(new PermissionMap())
                                       .Add(new RolePermissionsMapMap());
            base.OnModelCreating(modleBuilder);
        }
    }
}
