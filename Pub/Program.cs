using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("152.136.51.92:6379");
            IDatabase db = redis.GetDatabase();
            ISubscriber sub = redis.GetSubscriber();
            sub.Publish("messages", "this is message");
        }
    }
}
