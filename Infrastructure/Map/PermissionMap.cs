using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Infrastructure.Map
{
    public class PermissionMap:EntityTypeConfiguration<Permissions>
    {
        public PermissionMap()
        {

        }
    }
}
