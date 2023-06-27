using System.Net;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    // Certificate from File
    GlobalVariables.CertificateInfo = "File";
    //serverOptions.ConfigureHttpsDefaults(listenOptions =>
    //{
    //    listenOptions.ServerCertificate = new X509Certificate2("C:\\Users\\Max\\Documents\\Certificate\\certificate.pfx", "123");
    //});
    serverOptions.Listen(IPAddress.Any, 5001, listenOptions =>
    {
        public IConfiguration Configuration { get; }

        public static void Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<Worker>();

            IHost host = builder.Build();
            host.Run();
        }

    // Certificate from Personal Store
    //GlobalVariables.CertificateInfo = "Personal Store";
    //serverOptions.Listen(IPAddress.Any, 5001, listenOptions =>
    //{
    //    using (var store = new X509Store(StoreName.My, StoreLocation.LocalMachine))
    //    {
    //        store.Open(OpenFlags.ReadOnly);

    //        var certs = store.Certificates.Find(X509FindType.FindByIssuerName, "MaComutor", validOnly: false);

    //        if (certs.Count > 0)
    //        {
    //            var cert = certs[0];
    //            listenOptions.UseHttps(cert);
    //        }
    //        else
    //        {
    //            throw new Exception("No certificate found with thumbprint: <thumbprint>");
    //        }
    //    }
    //});
});


    //                    // Configure the HTTP request pipeline.
    //                    if (env.IsDevelopment())
    //                    {
    //                        app.UseDeveloperExceptionPage();
    //                    }

    //                    app.UseHttpsRedirection();
    //                    app.UseAuthorization();
    //                    app.UseRouting();
    //                    app.UseEndpoints(endpoints =>
    //                    {
    //                        endpoints.MapControllers();
    //                    });
    //                });  
    //            })
    //            .ConfigureServices((hostContext, services) =>
    //            {
    //                // Add controllers
    //                services.AddControllers();

    //                // Configure CloudEvent serialization and deserialization
    //                services.AddSingleton<CloudEventFormatter, JsonEventFormatter>();
    //                services.AddHttpContextAccessor();
    //            });

public static class GlobalVariables
{
    // Create a static field
    public static string? CertificateInfo;
}