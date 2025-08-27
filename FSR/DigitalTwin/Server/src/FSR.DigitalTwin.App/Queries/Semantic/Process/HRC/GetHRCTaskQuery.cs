using System.Text.Json;
using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Common.Utils.Semantic;
using FSR.DigitalTwin.App.Interfaces.Queries.Semantic;
using FSR.DigitalTwin.Domain.Model.Process.HRC.Task;
using FSR.DigitalTwin.Domain.SharedKernel;
using VDS.RDF;
using VDS.RDF.Nodes;
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
  	OPTIONAL {{ 
  		?task soho:hasTarget ?target .
  		?target a ?targetType .
  		?targetType rdfs:subClassOf+ soho:ProductionObject .
  		NOT EXISTS {{ ?target a ?otherType . ?otherType rdfs:subClassOf ?targetType . }}
	}}
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
    
    private static readonly UriNode _hasTarget = new(new Uri(KnownPrefix.SOHO + "hasTarget"));
    private static readonly UriNode _hasProcedureName = new(new Uri(KnownPrefix.SOHO + "hasProcedureName"));
    private static readonly UriNode _hasGoal = new(new Uri(KnownPrefix.SOHO + "hasGoal"));
    private static readonly UriNode _canBePerformedBy = new(new Uri(KnownPrefix.SOHO + "canBePerformedBy"));
    private static readonly UriNode _hasDuration = new(new Uri(KnownPrefix.SOHO + "hasDuration"));
    private static readonly UriNode _hasDurationUncertainty = new(new Uri(KnownPrefix.SOHO + "hasDurationUncertainty"));
    private static readonly UriNode _type = new(new Uri(KnownPrefix.RDF + "type"));
    private static readonly UriNode _label = new(new Uri(KnownPrefix.RDFS + "label"));
    private static readonly UriNode _productionObject = new(new Uri(KnownPrefix.SOHO + "ProductionObject"));
    private static readonly UriNode _productionTask = new(new Uri(KnownPrefix.SOHO + "ProductionTask"));
    private static readonly UriNode _cobot = new(new Uri(KnownPrefix.SOHO + "Cobot"));
    private static readonly UriNode _human = new(new Uri(KnownPrefix.SOHO + "Human"));

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
                AddOptionalTriple(binding, triples, task, _label, "name");
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

    private HRCTask CreateTask(OntologyGraph graph)
    {
        var node = new UriNode(new Uri(_taskUri));
        var function = graph.CreateIndividual(node);
        var type = function.Types
            .Select(p => graph.CreateOntologyClass(p))
            .FirstOrDefault(graph.CreateOntologyClass(_productionTask));
        var target = function.GetResourceProperty(_hasTarget.Uri)
            .Select(p => graph.CreateIndividual(p))
            .FirstOrDefault();
        string? goal = function.GetLiteralProperty(_hasGoal.Uri)
            .Select(l => l.Value)
            .FirstOrDefault();
        long duration = function.GetLiteralProperty(_hasDuration.Uri)
            .Where(l => l.DataType == new Uri(KnownPrefix.XSD + "long"))
            .Select(l => l.AsValuedNode().AsInteger())
            .FirstOrDefault(0);
        long durationUncertainty = function.GetLiteralProperty(_hasDurationUncertainty.Uri)
            .Where(l => l.DataType == new Uri(KnownPrefix.XSD + "long"))
            .Select(l => l.AsValuedNode().AsInteger())
            .FirstOrDefault(0);
        var performedBy = function.GetResourceProperty(_canBePerformedBy.Uri)
            .Select(p => graph.CreateIndividual(p));
        var hasCobot = performedBy.Where(p => p.Types.Contains(_cobot)).Any();
        var hasHuman = performedBy.Where(p => p.Types.Contains(_human)).Any();
        string agent = hasCobot && hasHuman ? "any" : hasCobot ? "robot" : "human";
        return new HRCTask(function) { Type = type, Target = target, Goal = goal, Agent = agent,
            AverageDuration = duration, DurationUncertainty = durationUncertainty };
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
        return Result.Success(CreateTask(graph));
    }

    public async Task<Result<HRCTask>> RunAsync(CancellationToken cancellationToken = default)
    {
        var response = await SparqlServer.QueryAsync(this, cancellationToken);
        if (response.IsFailure)
        {
            return Result.Failure<HRCTask>(response.Error);
        }
        OntologyGraph graph = new();
        foreach (Triple triple in response.Value)
        {
            graph.Assert(triple);
        }
        return Result.Success(CreateTask(graph));
    }
}