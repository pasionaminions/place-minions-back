using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace place_minions_back
{
    public class Program
    {
        public static string HistoryPath = Path.GetFullPath(@".\place-history.csv");
        public static string MapPath = Path.GetFullPath(@".\place-map.csv");

        public static BinaryFormatter bf = new BinaryFormatter();

        public static void Main(string[] args)
        {
            if (!(File.Exists(HistoryPath) && File.Exists(MapPath)))
            {
                File.WriteAllText(HistoryPath, "ts,x,y,col\n");
                byte[] arr = new byte[100 * 100];
                File.WriteAllText(MapPath, String.Join('\n', arr));
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
