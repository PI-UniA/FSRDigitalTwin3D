// Comment out definitions if unwanted
#define ENABLE_ONTOLOGY

using AasSecurity;
using FSR.DigitalTwin.App.Interfaces.Services.Semantic;

Console.WriteLine("AASX Server Core starting....");
var host = CreateHostBuilder(args).Build();

AasxServer.Program.Main(args);
SecurityHelper.SecurityInit();

#if ENABLE_ONTOLOGY // Enable OWL ontology
var serviceProvider = host.Services;
var ontoModel = serviceProvider.GetService<IOntologyModelService>()
    ?? throw new NullReferenceException("should not happen");
string sohoOntologyPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "../../modules/SOHO/core/soho_core.owl");
await ontoModel.DeleteOntologyModelAsync();
if (File.Exists(sohoOntologyPath)) {
    await ontoModel.LoadOntologyModelAsync(sohoOntologyPath, OntologyModelFileFormat.RDF_XML);
}
#endif

// Run file
await host.RunAsync();
await host.WaitForShutdownAsync();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
