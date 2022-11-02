using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.File;

namespace Otus.LoggingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                /*
                .ConfigureLogging(options =>
                {
                    options.AddEventLog();
                })
                */
                /*
                .UseSerilog((context, services, configuration) =>
                    configuration
                        .ReadFrom.Configuration(context.Configuration)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        
                        //.WriteTo.EventLog("Otus", manageEventSource: true)
                
                        .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                        {

                            FailureCallback = e =>
                            {
                                Console.WriteLine("Unable to submit event " + e.Exception);
                            },
                            FailureSink = new FileSink("./failures.txt", new JsonFormatter(), null),


                            TypeName = null,

                            IndexFormat = "otus-log",
                            AutoRegisterTemplate = true,
                            EmitEventFailure = EmitEventFailureHandling.ThrowException | EmitEventFailureHandling.RaiseCallback | EmitEventFailureHandling.WriteToSelfLog
                        })

                        .WriteTo.Seq("http://localhost:5341")
                         )
                */

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }
                );
    }
}