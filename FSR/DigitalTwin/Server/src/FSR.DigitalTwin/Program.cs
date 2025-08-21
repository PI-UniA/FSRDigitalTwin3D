// Comment out definitions if unwanted
#define ENABLE_ONTOLOGY_MODEL

using AasSecurity;
using FSR.DigitalTwin.App.Interfaces.Services.Semantic;
using FSR.DigitalTwin.App.Queries.Semantic.Process.HRC;
using FSR.DigitalTwin.Domain.Model.Process.HRC.Agent;
using FSR.DigitalTwin.Infra.Jena;
using Microsoft.Extensions.Options;

Console.WriteLine("AASX Server Core starting....");
var host = CreateHostBuilder(args).Build();

AasxServer.Program.Main(args);
SecurityHelper.SecurityInit();

#if ENABLE_ONTOLOGY_MODEL // Enable OWL ontology model
var ontoModel = host.Services.GetService<IOntologyModelService>()
    ?? throw new NullReferenceException("should not happen");
var tripleCount = ontoModel.Count;
var ontoOptions = host.Services.GetRequiredService<IOptions<JenaSemanticDataRepositoryOptions>>().Value;
await ontoModel.DeleteOntologyModelAsync();
foreach (string modelFile in ontoOptions.ModelFiles)
{
    string ontoModelPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), modelFile);
    if (!File.Exists(ontoModelPath))
        continue;
    await ontoModel.LoadOntologyModelAsync(ontoModelPath, OntologyModelFileFormat.RDF_XML);
}
var cobots = await ontoModel.RunSparqlQueryAsync((server) => new GetCobotAgentsQuery() { SparqlServer = server });
if (cobots.IsSuccess)
{
    foreach (Cobot cobot in cobots.Value)
    {
        Console.WriteLine("Got Cobot: " + cobot.Resource);
    }
}
Console.WriteLine("Number of triples loaded in semantic database: " + tripleCount);
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
