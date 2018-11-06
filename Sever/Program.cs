using NewLife.Log;
using NewLife.Net;
using NewLife.Net.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sever
{
    class Program
    {
        static void Main(string[] args)
        {
            var svr = new NetServer
            {
                Port = 1234,
                Log = XTrace.Log,
                SessionLog = XTrace.Log,
                SocketLog = XTrace.Log,
            };
            svr.Add<StandardCodec>();
            svr.Add<EchoHandler>();
            svr.Start();
            Console.ReadKey();
        }
    }
}
