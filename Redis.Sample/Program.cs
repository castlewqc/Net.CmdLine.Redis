using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis.Sample
{
    using StackExchange.Redis;

    class Program
    {
        //ServiceStack.Redis
        //public static ServiceStack.Redis.RedisClient client 
        //    = new ServiceStack.Redis.RedisClient("152.136.51.92", 6379);

        static void Main(string[] args)
        {
            //多路调制器
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("152.136.51.92:6379");
            IDatabase db = redis.GetDatabase();
            db.StringSet("name", "_name");
            db.StringSet("password", "_pwd");
            var name = db.StringGet("name"); //RedisValue
            string pwd = db.StringGet("password");

            Console.WriteLine(string.Format("{0}-{1}", name, pwd));
            ISubscriber sub = redis.GetSubscriber();
            sub.Subscribe("messages", (channel, message) => {
                Console.WriteLine(message);
            });
          
            Console.ReadLine();
        }
    }
}
