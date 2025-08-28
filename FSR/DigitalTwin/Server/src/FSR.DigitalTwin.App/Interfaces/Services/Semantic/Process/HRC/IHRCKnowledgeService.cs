using FSR.DigitalTwin.Domain.Model.Process.HRC.Task;
using VDS.RDF;

namespace FSR.DigitalTwin.App.Interfaces.Services.Semantic.Process.HRC;

public interface IHRCKnowledgeService
{
    IEnumerable<INode> GetInstances(INode classINode);
    IEnumerable<INode> GetIndividuals(INode classINode);
    bool HasProperty(INode INode);
    bool HasResource(INode INode);
    bool HasResourceType(INode INode, INode classINode);
    bool HasIndividual(INode INode);
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
    IEnumerable<FunctionData> GetFunctionDataProperties(INode func);
    IEnumerable<FunctionObjectData> GetFunctionObjectProperties(INode func);
}