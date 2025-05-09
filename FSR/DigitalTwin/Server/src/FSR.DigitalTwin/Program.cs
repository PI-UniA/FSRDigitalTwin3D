// Comment out definitions if unwanted
#define ENABLE_ONTOLOGY

using AasSecurity;
using FSR.DigitalTwin.App.Interfaces.Services.Semantic;

Console.WriteLine("AASX Server Core starting....");
var host = CreateHostBuilder(args).Build();

AasxServer.Program.Main(args);
SecurityHelper.SecurityInit();

#if ENABLE_ONTOLOGY // Enable OWL ontology
const int OWL_ONTOLOGY_TRIPLE_COUNT = 644;
var serviceProvider = host.Services;
var ontology = serviceProvider.GetService<IOwlOntologyService>()
    ?? throw new NullReferenceException("should not happen");
// await ontology.DeleteOntologyAsync();
if (ontology.Count == OWL_ONTOLOGY_TRIPLE_COUNT) {
    await ontology.CreateOntologyAsync();
    // We also want to load the SOHO ontology for human-robot-collaboration if present
    string sohoOntologyPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "../../modules/SOHO/core/soho_core.owl");
    if (File.Exists(sohoOntologyPath)) {
        await ontology.CreateOntologyFromFileAsync(sohoOntologyPath, "application/rdf+xml");
    }
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
