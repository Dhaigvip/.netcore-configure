using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Dotnetcore_Extending
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                   
                    //webBuilder.UseKestrel(options =>
                    //{
                    //    //Listen for localhost on Http
                    //    options.Listen(IPAddress.Loopback, 5001);

                    //    options.Listen(IPAddress.Loopback, 5002, listenOptions => { listenOptions.UseHttps(); });

                    //});
                    webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                    //Configure to add a console log provider.
                    //You can implement a log provider, register with ILoggerFactory 
                    webBuilder.ConfigureLogging(builder => builder.AddConsole());
                });
    }
    /* LOG
     * Critical—For disastrous failures
     * Error—For errors and exceptions that you can’t handle gracefully
     * Warning—For when an unexpected or error condition
     * Information—For tracking normal application flow
     * Debug—For tracking detailed information that’s particularly useful during development
     * Trace—For tracking very detailed information, which may contain sensitive information like passwords or keys
     */

    /* LOG PROVIDERS
     * Console provider—Writes messages to the console
     * Debug provider—Writes messages to the debug window
     * EventLog provider—Writes messages to the Windows Event Log
     * EventSource provider—Writes messages using Event Tracing for Windows (ETW).
     * Azure App Service provider—Writes messages to text files or blob storage if you’re running your app in Microsoft’s Azure cloud service
     */

    /*
     * SSL
     * app.UseHttpsRedirection() //Http -> Https
     * POWERSHELL
     * 1.
     * $cert = New-SelfSignedCertificate -Subject localhost `
       -DnsName localhost -KeyUsage DigitalSignature `
       -FriendlyName "ASP.NET Core Development" `
       -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.1")
       $mypwd = ConvertTo-SecureString -Force –AsPlainText `
       -String "testpassword"
       Export-PfxCertificate -Cert $cert -Password $mypwd `
       -FilePath .\test-certificate.pfx
       2. ADD TO TRUSTED STORE
       Import-PfxCertificate -FilePath .\test-certificate.pfx -Password $mypwd -
       CertStoreLocation cert:/CurrentUser/Root
     */
}
