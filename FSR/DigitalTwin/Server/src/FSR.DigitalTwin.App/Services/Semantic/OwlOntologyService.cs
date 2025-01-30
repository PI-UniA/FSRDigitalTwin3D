using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Interfaces.Services.Semantic;
using FSR.DigitalTwin.Domain.SharedKernel;
using Microsoft.Extensions.Logging;
using VDS.RDF;
using VDS.RDF.Parsing;

namespace FSR.DigitalTwin.App.Services.Semantic;

public class OwlOntologyService : IOwlOntologyService
{
    private readonly ISemanticDataRepository _semanticDataRepository;
    private readonly ILogger<OwlOntologyService> _logger;

    public OwlOntologyService(ISemanticDataRepository semanticDataRepository, ILogger<OwlOntologyService> logger) {
        _semanticDataRepository = semanticDataRepository ?? throw new ArgumentNullException(nameof(semanticDataRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    private static Tuple<string, string, string>[] ReadTriplesFromOwl(string filePath)
    {
        var graph = new Graph();
        var parser = new RdfXmlParser();

        using (var stream = File.OpenRead(filePath))
        {
            parser.Load(graph, new StreamReader(stream));
        }

        var triples = new List<Tuple<string, string, string>>();

        foreach (Triple triple in graph.Triples)
        {
            string subject = triple.Subject.ToString();
            string predicate = triple.Predicate.ToString();
            string obj = triple.Object.ToString();

            triples.Add(Tuple.Create(subject, predicate, obj));
        }

        return triples.ToArray();
    }

    public async Task<Result<bool>> CreateOntologyAsync()
    {
        string projectDirectory = Directory.GetCurrentDirectory();
        string fullPath = Path.Combine(projectDirectory, "owl");

        if (!Directory.Exists(fullPath))
        {
            throw new DirectoryNotFoundException($"Directory not found: {fullPath}");
        }

        var allTriples = new List<Tuple<string, string, string>>();

        foreach (var filePath in Directory.GetFiles(fullPath, "*.xml"))
        {
            Console.WriteLine($"Processing file: {Path.GetFileName(filePath)}");

            try
            {
                var triples = ReadTriplesFromOwl(filePath);
                allTriples.AddRange(triples);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filePath}: {ex.Message}");
            }
        }

        // TODO Currently DoS-attacks the server
        await _semanticDataRepository.AddAllAsync(allTriples.ToArray());

        return Result.Success(true);
    }
}