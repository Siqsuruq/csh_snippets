using Microsoft.Extensions.Hosting;
using CloudNative.CloudEvents;
using CloudNative.CloudEvents.Http;
using CloudNative.CloudEvents.NewtonsoftJson;

namespace REST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.Configure(app =>
                    {
                        var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

                        // Configure the HTTP request pipeline.
                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }

                        app.UseHttpsRedirection();
                        app.UseAuthorization();
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                })
                .ConfigureServices((hostContext, services) =>
                {
                    // Add controllers
                    services.AddControllers();

                    // Configure CloudEvent serialization and deserialization
                    services.AddSingleton<CloudEventFormatter, JsonEventFormatter>();
                    services.AddHttpContextAccessor();
                });

    }
}