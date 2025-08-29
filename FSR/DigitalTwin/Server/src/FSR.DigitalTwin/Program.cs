// Comment out definitions if unwanted
#define ENABLE_ONTOLOGY_MODEL

using AasSecurity;
using FSR.DigitalTwin.App.Common.Utils.Semantic;
using FSR.DigitalTwin.App.Interfaces.Services.Semantic;
using FSR.DigitalTwin.App.Queries.Semantic.Base;
using FSR.DigitalTwin.App.Queries.Semantic.Process.HRC;
using FSR.DigitalTwin.Infra.Jena;
using Microsoft.Extensions.Options;
using VDS.RDF;

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
await RunOntologyDemoQueriesAsync(ontoModel);
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

static async Task RunOntologyDemoQueriesAsync(IOntologyModelService ontoModel)
{
    var cobots = await ontoModel.RunSparqlQueryAsync((server) => new GetIndividualsQuery(UriPrefix.SOHO + "Cobot") { SparqlServer = server });
    if (cobots.IsSuccess)
    {
        foreach (var cobot in cobots.Value)
        {
            Console.WriteLine("Got Cobot: " + cobot);
        }
    }
    var pickPlaceTasks = await ontoModel.RunSparqlQueryAsync((server) => new GetIndividualsQuery(UriPrefix.SOHO + "PickPlace") { SparqlServer = server });
    if (pickPlaceTasks.IsSuccess)
    {
        foreach (UriNode pp in pickPlaceTasks.Value.Where(n => n.NodeType == VDS.RDF.NodeType.Uri).Cast<UriNode>())
        {
            var functionData = await ontoModel.RunSparqlQueryAsync((server) => new GetFunctionPropertyDataQuery(pp.Uri) { SparqlServer = server });
            var functionObjects = await ontoModel.RunSparqlQueryAsync((server) => new GetFunctionObjectDataQuery(pp.Uri) { SparqlServer = server });
            if (functionData.IsFailure || functionObjects.IsFailure)
                continue;
            Console.WriteLine($"Got PickPlace: {functionData.Value.Function.Uri}, Traget: {functionObjects.Value.Target.FirstOrDefault()}, Duration: {functionData.Value.Duration}");
        }
    }
}