using AasSecurity;

Console.WriteLine("AASX Server Core starting....");
var host = CreateHostBuilder(args).Build();

AasxServer.Program.Main(args);
SecurityHelper.SecurityInit();

// Run file
await host.RunAsync();
await host.WaitForShutdownAsync();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
