using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogAbstraction;
using NLog;

namespace Infrastructure.Database
{
   public  class OurInterception: DbCommandInterceptor
    {
        private ILogger _logger = LogManager.GetLogger("sql");


        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) {
            _logger.Info($"NonQuery:{command.CommandText}");
            base.NonQueryExecuting(command, interceptionContext);
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) {
            _logger.Info($"Reader:{command.CommandText}");
            base.ReaderExecuting(command, interceptionContext);
        }
        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) {
            _logger.Info($"Scalar:{command.CommandText}");
            base.ScalarExecuted(command, interceptionContext);
        }
    }
}
