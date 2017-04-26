using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Re
{
    public class RedisConnectionMultiplexer
    {
        private static ConnectionMultiplexer _redis;
        private static object _locker = new object();
        public static ConnectionMultiplexer Manager
        {
            get {
                if (_redis == null)
                {
                    lock (_locker)
                    {
                        _redis = GetManager();
                        return _redis;
                    }
                }
                return _redis;
            }
        }

        public static ConnectionMultiplexer GetManager(string connectionString=null)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "localhost";
            }
            return ConnectionMultiplexer.Connect(connectionString);
        }

        public bool Remove(string key)
        {
            var db = RedisConnectionMultiplexer.Manager.GetDatabase();
            return false;
        }
    }
}
