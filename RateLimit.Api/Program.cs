using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreRateLimit;

namespace RateLimit.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webhost=CreateHostBuilder(args).Build();

            //IpRateLimit ucun nezerde tutulub

            // appsettings de olan IpRateLimitPolicies islemesi ucun gorulen isler
            //var IpPolicy = webhost.Services.GetRequiredService<IIpPolicyStore>();

            //IpPolicy.SeedAsync().Wait();

            webhost.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
