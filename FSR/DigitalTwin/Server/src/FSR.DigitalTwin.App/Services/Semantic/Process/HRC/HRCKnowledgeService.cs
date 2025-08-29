using FSR.DigitalTwin.App.Common.Utils.Semantic;
using FSR.DigitalTwin.App.Ex;
using FSR.DigitalTwin.App.Interfaces.Services.Semantic;
using FSR.DigitalTwin.App.Interfaces.Services.Semantic.Process.HRC;
using FSR.DigitalTwin.App.Queries.Semantic.Base;
using FSR.DigitalTwin.App.Queries.Semantic.Process.HRC;
using FSR.DigitalTwin.Domain.Model.Process.HRC.Task;
using Microsoft.Extensions.Logging;
using VDS.RDF;

namespace FSR.DigitalTwin.App.Services.Semantic.Process.HRC;

public class HRCKnowledgeService : IHRCKnowledgeService
{
    private readonly IOntologyModelService _ontology;
    private readonly ILogger<HRCKnowledgeService> _logger;

    public HRCKnowledgeService(IOntologyModelService ontology, ILogger<HRCKnowledgeService> logger)
    {
        _ontology = ontology ?? throw new ArgumentNullException(nameof(ontology));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public IEnumerable<INode> GetAgents()
    {
        var result = _ontology.RunSparqlQuery((server) =>
            new GetInstancesQuery(UriPrefix.SOHO + "AutonomousAgent") { SparqlServer = server });
        return result.IsSuccess ? result.Value.Distinct() : [];
    }

    public IEnumerable<INode> GetBinaryResources()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<INode> GetCobots()
    {
        var result = _ontology.RunSparqlQuery((server) =>
            new GetInstancesQuery(UriPrefix.SOHO + "Cobot") { SparqlServer = server });
        return result.IsSuccess ? result.Value.Distinct() : [];
    }

    public IEnumerable<INode> GetCompoundGoals()
    {
        var result = _ontology.RunSparqlQuery((server) =>
            new GetInstancesQuery(UriPrefix.SOHO + "CompoundProductionGoal") { SparqlServer = server });
        return result.IsSuccess ? result.Value.Distinct() : [];
    }

    public IEnumerable<IDictionary<INode, IEnumerable<ISet<INode>>>> GetDecompositionGraph(Uri pGoal)
    {
        throw new NotImplementedException();
    }

    public IDictionary<INode, ISet<INode>> GetDependencyGraph(Uri resource)
    {
        throw new NotImplementedException();
    }

    public FunctionPropertyData GetFunctionDataProperties(Uri function)
    {
        var result = _ontology.RunSparqlQuery((server) =>
            new GetFunctionPropertyDataQuery(function) { SparqlServer = server });
        if (result.IsFailure)
        {
            return new FunctionPropertyData()
            {
                Function = new UriNode(function),
                ProcedureId = null,
                ProcedureName = null,
                ProcedureDescription = null,
                Duration = 0,
                DurationUncertainty = 0
            };
        }
        return result.Value;
    }

    public FunctionObjectData GetFunctionObjectProperties(Uri function)
    {
        var result = _ontology.RunSparqlQuery((server) =>
            new GetFunctionObjectDataQuery(function) { SparqlServer = server });
        if (result.IsFailure)
        {
            return new FunctionObjectData()
            {
                Function = new UriNode(function),
                Target = [],
                StartLocation = [],
                EndLocation = [],
                Location = []
            };
        }
        return result.Value;
    }

    public IEnumerable<INode> GetFunctions()
    {
        var result = _ontology.RunSparqlQuery((server) =>
            new GetInstancesQuery(UriPrefix.SOHO + "Function") { SparqlServer = server });
        return result.IsSuccess ? result.Value.Distinct() : [];
    }

    public IEnumerable<INode> GetFunctionsByAgent(Uri agent)
    {
        throw new NotImplementedException();
    }

    public INode GetFunctionTarget(Uri function)
    {
        var functionObjects = GetFunctionObjectProperties(function);
        if (functionObjects.Target.Count == 0)
        {
            throw new HRCKnowledgeException($"Missing SOHO:hasTarget property for function: {function}");
        }
        return functionObjects.Target.First();
    }

    public IEnumerable<INode> GetWorkerOperators()
    {
        var result = _ontology.RunSparqlQuery((server) =>
            new GetInstancesQuery(UriPrefix.SOHO + "WorkerOperator") { SparqlServer = server });
        return result.IsSuccess ? result.Value.Distinct() : [];
    }

    public IEnumerable<INode> GetHumans()
    {
        var result = _ontology.RunSparqlQuery((server) =>
            new GetInstancesQuery(UriPrefix.SOHO + "Human") { SparqlServer = server });
        return result.IsSuccess ? result.Value.Distinct() : [];
    }

    public IEnumerable<INode> GetIndividuals(Uri classRes)
    {
        var result = _ontology.RunSparqlQuery((server) =>
            new GetIndividualsQuery(classRes) { SparqlServer = server });
        return result.IsSuccess ? result.Value.Distinct() : [];
    }

    public IEnumerable<INode> GetInstances(Uri classRes)
    {
        var result = _ontology.RunSparqlQuery((server) =>
            new GetInstancesQuery(classRes) { SparqlServer = server });
        return result.IsSuccess ? result.Value.Distinct() : [];
    }

    public IEnumerable<INode> GetProductionGoals()
    {
        var result = _ontology.RunSparqlQuery((server) =>
            new GetInstancesQuery(UriPrefix.SOHO + "ProductionGoal") { SparqlServer = server });
        return result.IsSuccess ? result.Value.Distinct() : [];
    }

    public IEnumerable<IEnumerable<INode>> GetProductionHierarchy(Uri pGoal)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<INode> GetProductionSubgoals()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<INode> GetProperty(Uri individual, Uri property)
    {
        var result = _ontology.RunSparqlQuery((server) =>
            new GetPropertyQuery(individual, property) { SparqlServer = server });
        return result.IsSuccess ? result.Value : [];
    }

    public INode GetResourceType(Uri resource)
    {
        var result = _ontology.RunSparqlQuery((server) =>
            new GetPropertyQuery(resource, UriPrefix.RDF + "type") { SparqlServer = server });
        if (result.IsFailure || !result.Value.Any())
        {
            throw new HRCKnowledgeException($"Missing RDF:type property for resource: {resource}");
        }
        return result.Value.Last();
    }

    public bool HasResourceType(Uri resource, Uri type)
    {
        var result = _ontology.RunSparqlQuery((server) =>
            new GetInstancesQuery(type) { SparqlServer = server });
        return result.IsSuccess && result.Value.Where(n => n.NodeType == NodeType.Uri)
            .Cast<UriNode>().Contains(new UriNode(resource));
    }

    public IDictionary<INode, ISet<INode>> RetrieveResourceStructure(Uri resource)
    {
        throw new NotImplementedException();
    }
}