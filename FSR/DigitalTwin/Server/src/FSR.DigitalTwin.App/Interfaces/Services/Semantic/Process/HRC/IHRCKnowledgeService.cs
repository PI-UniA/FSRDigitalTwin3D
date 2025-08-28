using FSR.DigitalTwin.Domain.Model.Process.HRC.Task;
using VDS.RDF;

namespace FSR.DigitalTwin.App.Interfaces.Services.Semantic.Process.HRC;

public interface IHRCKnowledgeService
{
    IEnumerable<INode> GetInstances(INode classRes);
    IEnumerable<INode> GetIndividuals(INode classRes);
    bool HasProperty(INode property);
    bool HasResource(INode resource);
    bool HasResourceType(INode resource, INode classRes);
    bool HasIndividual(INode resource);
    IDictionary<INode, ISet<INode>> RetrieveResourceStructure(INode resource);
    IEnumerable<INode> GetProductionGoals();
    IEnumerable<INode> GetAgents();
    IEnumerable<INode> GetHumans();
    IEnumerable<INode> GetCobots();
    IEnumerable<INode> GetFunctions();
    IEnumerable<INode> GetFunctionsByAgent(INode agent);
    IEnumerable<IDictionary<INode, IEnumerable<ISet<INode>>>> GetDecompositionGraph(INode pGoal);
    IDictionary<INode, ISet<INode>> GetDependencyGraph(INode resource);
    IEnumerable<IEnumerable<INode>> GetProductionHierarchy(INode pGoal);
    INode GetResourceType(INode resource);
    INode GetFunctionTarget(INode function);
    IEnumerable<FunctionData> GetFunctionDataProperties(INode function);
    IEnumerable<FunctionObjectData> GetFunctionObjectProperties(INode function);
}