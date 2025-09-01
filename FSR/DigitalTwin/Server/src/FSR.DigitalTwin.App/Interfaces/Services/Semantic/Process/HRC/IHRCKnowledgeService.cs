using FSR.DigitalTwin.Domain.Model.Process.HRC.Task;
using VDS.RDF;

namespace FSR.DigitalTwin.App.Interfaces.Services.Semantic.Process.HRC;

public interface IHRCKnowledgeService
{
    IEnumerable<INode> GetInstances(Uri classRes);
    IEnumerable<INode> GetIndividuals(Uri classRes);
    IEnumerable<INode> GetProperty(Uri individual, Uri property);
    bool HasResourceType(Uri resource, Uri type);
    IDictionary<INode, ISet<INode>> RetrieveResourceStructure(Uri resource);
    IEnumerable<INode> GetProductionGoals();
    IEnumerable<INode> GetCompoundGoals();
    IEnumerable<INode> GetProductionSubgoals();
    IEnumerable<INode> GetBinaryResources();
    IEnumerable<INode> GetAgents();
    IEnumerable<INode> GetWorkerOperators();
    IEnumerable<INode> GetHumans();
    IEnumerable<INode> GetCobots();
    IEnumerable<INode> GetFunctions();
    IEnumerable<INode> GetFunctionsByAgent(Uri agent);
    IEnumerable<IDictionary<INode, IList<ISet<INode>>>> GetDecompositionGraph(Uri prodGoal);
    IDictionary<INode, ISet<INode>> GetDependencyGraph(Uri prodGoal);
    IEnumerable<IEnumerable<INode>> GetProductionHierarchy(Uri prodGoal);
    INode GetResourceType(Uri resource);
    INode GetFunctionTarget(Uri function);
    FunctionPropertyData GetFunctionDataProperties(Uri function);
    FunctionObjectData GetFunctionObjectProperties(Uri function);
}