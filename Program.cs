using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TSI.DAL;

namespace TSI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new DataContext();
            DataContextInitializer.Initialize(context);
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
