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
    IEnumerable<INode> GetGoals();
    IEnumerable<INode> GetCompoundGoals();
    IEnumerable<INode> GetSubgoals();
    IEnumerable<INode> GetBinaryResources();
    IEnumerable<INode> GetAgents();
    IEnumerable<INode> GetHumans();
    IEnumerable<INode> GetCobots();
    IEnumerable<INode> GetFunctions();
    IEnumerable<INode> GetFunctionsByAgent(Uri agent);
    IEnumerable<IDictionary<INode, IList<ISet<INode>>>> GetDecompositionGraph(Uri goal);
    IDictionary<INode, ISet<INode>> GetDependencyGraph(Uri goal);
    IEnumerable<IEnumerable<INode>> GetHierarchy(Uri goal);
    INode GetResourceType(Uri resource);
    INode GetFunctionTarget(Uri function);
    FunctionPropertyData GetFunctionDataProperties(Uri function);
    FunctionObjectData GetFunctionObjectProperties(Uri function);
}