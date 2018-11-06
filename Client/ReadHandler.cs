using System;
using System.Text;
using NewLife.Data;
using NewLife.Log;
using NewLife.Model;
using NewLife.Net;

namespace Client
{
    class ReadHandler : Handler
    {
        public override Object Read(IHandlerContext context, Object message)
        {
            var ctx = context as NetHandlerContext;
            var session = ctx.Session;
            var pk = message as Packet;
            //Console.WriteLine(Encoding.Default.GetString(pk.Data,0,pk.Total));
            Console.WriteLine(pk.Total);
            return null;
        }
    }
}
