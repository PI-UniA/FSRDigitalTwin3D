using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Common.Utils.Semantic;
using FSR.DigitalTwin.App.Interfaces.Queries.Semantic;
using FSR.DigitalTwin.Domain.Model.Process.HRC.Task;
using FSR.DigitalTwin.Domain.SharedKernel;
using VDS.RDF;

namespace FSR.DigitalTwin.App.Queries.Semantic.Process.HRC;

public class GetHRCTaskQuery : ISparqlQuery<HRCTask>
{
    public string Query => KnownPrefix.GetSparql() +
$@"
SELECT DISTINCT ?task ?taskType ?target ?name ?goal ?agent ?duration ?durationUncertainty
WHERE {{
    BIND(<{_taskUri}> AS ?task)
  
	?task a ?taskType .
  	?taskType rdfs:subClassOf+ soho:ProductionTask .
    NOT EXISTS {{
  		?task a ?otherType .
  		?otherType rdfs:subClassOf ?taskType .
	}}
  
  	OPTIONAL {{ ?task soho:hasTarget ?target . }}
    OPTIONAL {{ ?task soho:hasProcedureName ?name . }}
  	OPTIONAL {{ ?task soho:hasGoal ?goal . }}
    OPTIONAL {{ ?task soho:canBePerformedBy ?agent . }}
  	OPTIONAL {{ ?task soho:hasDuration ?duration . }}
  	OPTIONAL {{ ?task soho:hasDurationUncertainty ?durationUncertainty . }}
}}
";
    public ISparqlResponseParser Parser => new ResponseParser();
    public ISparqlServer SparqlServer { get => _sparqlServer ?? throw new NullReferenceException(); init => _sparqlServer = value; }
    private readonly ISparqlServer? _sparqlServer;
    private readonly string _taskUri;

    private class ResponseParser : ISparqlResponseParser
    {
        public IEnumerable<Triple> FromJson(string jsonResponse)
        {
            throw new NotImplementedException();
        }
    }

    public GetHRCTaskQuery(string taskUri)
    {
        _taskUri = taskUri;
    }

    public Result<HRCTask> Run()
    {
        throw new NotImplementedException();
    }

    public Task<Result<HRCTask>> RunAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}