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
        listenOptions.UseHttps();
    });

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


var app = builder.Build();
var a = GlobalVariables.CertificateInfo;
string WherIsCert = $"Hello World! Certificate is from the {a}";
app.MapGet("/", () => WherIsCert);
app.Run();


public static class GlobalVariables
{
    // Create a static field
    public static string? CertificateInfo;
}