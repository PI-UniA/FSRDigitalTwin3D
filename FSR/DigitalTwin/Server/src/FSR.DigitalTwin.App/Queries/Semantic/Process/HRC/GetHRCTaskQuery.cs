using System.Text.Json;
using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Common.Utils.Semantic;
using FSR.DigitalTwin.App.Interfaces.Queries.Semantic;
using FSR.DigitalTwin.Domain.Model.Process.HRC.Task;
using FSR.DigitalTwin.Domain.SharedKernel;
using Namotion.Reflection;
using VDS.RDF;
using VDS.RDF.Ontology;

namespace FSR.DigitalTwin.App.Queries.Semantic.Process.HRC;

public class GetHRCTaskQuery : ISparqlQuery<HRCTask>
{
    public string Query => KnownPrefix.GetSparql() +
$@"
SELECT DISTINCT ?task ?taskType ?target ?name ?goal ?human ?cobot ?duration ?durationUncertainty
WHERE {{
    BIND(<{_taskUri}> AS ?task)
  
	?task a ?taskType .
  	?taskType rdfs:subClassOf+ soho:ProductionTask .
    NOT EXISTS {{ ?task a ?otherType . ?otherType rdfs:subClassOf ?taskType . }}
  	OPTIONAL {{ ?task soho:hasTarget ?target . }}
    OPTIONAL {{ ?task soho:hasProcedureName ?name . }}
  	OPTIONAL {{ ?task soho:hasGoal ?goal . }}
    OPTIONAL {{ ?task soho:canBePerformedBy ?human . ?human rdf:type soho:Human . }}
  	OPTIONAL {{ ?task soho:canBePerformedBy ?cobot . ?cobot rdf:type soho:Cobot . }}
  	OPTIONAL {{ ?task soho:hasDuration ?duration . }}
  	OPTIONAL {{ ?task soho:hasDurationUncertainty ?durationUncertainty . }}
}}
";
    public ISparqlResponseParser Parser => new ResponseParser();
    public ISparqlServer SparqlServer { get => _sparqlServer ?? throw new NullReferenceException(); init => _sparqlServer = value; }
    private readonly ISparqlServer? _sparqlServer;
    private readonly string _taskUri;
    
    private static readonly BaseNode _hasTarget = new UriNode(new Uri(KnownPrefix.SOHO + "hasTarget"));
    private static readonly BaseNode _hasProcedureName = new UriNode(new Uri(KnownPrefix.SOHO + "hasProcedureName"));
    private static readonly BaseNode _hasGoal = new UriNode(new Uri(KnownPrefix.SOHO + "hasGoal"));
    private static readonly BaseNode _canBePerformedBy = new UriNode(new Uri(KnownPrefix.SOHO + "canBePerformedBy"));
    private static readonly BaseNode _hasDuration = new UriNode(new Uri(KnownPrefix.SOHO + "hasDuration"));
    private static readonly BaseNode _hasDurationUncertainty = new UriNode(new Uri(KnownPrefix.SOHO + "hasDurationUncertainty"));
    private static readonly BaseNode _type = new UriNode(new Uri(KnownPrefix.RDF + "type"));
    private static readonly BaseNode _productionObject = new UriNode(new Uri(KnownPrefix.SOHO + "ProductionObject"));
    private static readonly BaseNode _productionTask = new UriNode(new Uri(KnownPrefix.SOHO + "ProductionTask"));
    private static readonly BaseNode _cobot = new UriNode(new Uri(KnownPrefix.SOHO + "Cobot"));
    private static readonly BaseNode _human = new UriNode(new Uri(KnownPrefix.SOHO + "Human"));

    private class ResponseParser : ISparqlResponseParser
    {
        public IEnumerable<Triple> FromJson(string jsonResponse)
        {
            var json = JsonDocument.Parse(jsonResponse);
            var bindings = json.RootElement.GetProperty("results").GetProperty("bindings");

            var triples = new List<Triple>();
            foreach (var binding in bindings.EnumerateArray())
            {
                if (!binding.TryGetProperty("task", out JsonElement task_) ||
                    !binding.TryGetProperty("taskType", out JsonElement taskType_))
                    continue;

                var task = RdfNodeFactory.CreateFromJson(task_);
                var taskType = RdfNodeFactory.CreateFromJson(taskType_);
                triples.Add(new Triple(task, _type, taskType));

                AddOptionalTriple(binding, triples, task, _hasTarget, "target", _productionObject);
                AddOptionalTriple(binding, triples, task, _hasProcedureName, "name");
                AddOptionalTriple(binding, triples, task, _hasGoal, "goal");
                AddOptionalTriple(binding, triples, task, _canBePerformedBy, "human", _human);
                AddOptionalTriple(binding, triples, task, _canBePerformedBy, "cobot", _cobot);
                AddOptionalTriple(binding, triples, task, _hasDuration, "duration");
                AddOptionalTriple(binding, triples, task, _hasDurationUncertainty, "durationUncertainty");
            }

            return triples;
        }

        private static void AddOptionalTriple(JsonElement binding, List<Triple> triples, INode subject, INode predicate, string propertyName, INode? objectType = null)
        {
            if (binding.TryGetProperty(propertyName, out JsonElement element))
            {
                var node = RdfNodeFactory.CreateFromJson(element);
                if (objectType != null)
                    triples.Add(new Triple(node, _type, objectType));
                triples.Add(new Triple(subject, predicate, node));
            }
        }
    }

    public GetHRCTaskQuery(string taskUri)
    {
        _taskUri = taskUri;
    }

    public Result<HRCTask> Run()
    {
        var response = SparqlServer.Query(this);
        if (response.IsFailure)
        {
            return Result.Failure<HRCTask>(response.Error);
        }
        OntologyGraph graph = new();
        foreach (Triple triple in response.Value)
        {
            graph.Assert(triple);
        }

        var node = new UriNode(new Uri(_taskUri));
        OntologyResource function = new Individual(node, graph);
        OntologyResource type = graph.Triples
            .Where(t => t.Subject as BaseNode == node && t.Predicate as BaseNode == _type)
            .Select(t => new OntologyClass(t.Object, graph))
            .FirstOrDefault(new OntologyClass(_productionTask, graph));

        HRCTask hrcTask = new(function, 0) { Type = type };
        // TODO Add optionals
        return Result.Success(hrcTask);
    }

    public Task<Result<HRCTask>> RunAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}