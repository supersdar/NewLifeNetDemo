using NewLife.Data;
using NewLife.Net;
using NewLife.Net.Handlers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {   
        static string data=null;
        static void Main(string[] args)
        {
            //10kb data pack      
            for (int i = 0; i < 1024; i++)
            {
                data += "1234567890";
            }
            try
            {
                var uri = new NetUri(ConfigurationManager.AppSettings["URI"]);
                var pk = new Packet(data.GetBytes());
                //
                var ts = new List<Task>();
                for (var i = 0; i < 10000; i++)
                {
                    var tsk = Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            var client = uri.CreateRemote();
                            client.Add<StandardCodec>();
                            client.Add<ReadHandler>();                            
                            client.Open();
                            for (var k = 0; k < 100; k++)
                            {                               
                                client.SendMessageAsync(pk);
                            }
                            return client;

                        }
                        catch { return null; }
                    }, TaskCreationOptions.LongRunning);
                    ts.Add(tsk);
                }
                Task.WaitAll(ts.ToArray());
                //
                Console.WriteLine("All The Job Have Done");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}
