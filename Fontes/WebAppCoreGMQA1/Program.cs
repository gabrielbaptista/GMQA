using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace WebAppCoreGMQA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (Debugger.IsAttached)
            {
                var host = new WebHostBuilder()
                 .UseKestrel()
                 .UseContentRoot(Directory.GetCurrentDirectory())
                 .UseStartup<Startup>()
                 .UseUrls("http://*:5000")
                 .Build();

                host.Run();
            }
            else
            {
                var host = new WebHostBuilder()
                 .UseKestrel()
                 .UseContentRoot(Directory.GetCurrentDirectory())
                 .UseStartup<Startup>()
                 .Build();

                host.Run();
            }
        }
    }
}
