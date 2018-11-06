using NewLife.Data;
using NewLife.Model;
using NewLife.Net;
using System;

namespace Sever
{
    class EchoHandler : Handler
    {

        public override Object Read(IHandlerContext context, Object message)
        {

                var ctx = context as NetHandlerContext;
                var session = ctx.Session;
                var pk = message as Packet;
                Console.WriteLine("收到：{0}", pk.Total);
                // 把收到的数据发回去
                session.SendMessage(pk);    
            return null;
        }
    }
}