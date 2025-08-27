namespace FSR.DigitalTwin.App.Interfaces.Services.Semantic.Process.HRC;

public interface IHRCKnowledgeService
{
    IEnumerable<Uri> GetInstances(Uri classUri);
    IEnumerable<Uri> GetIndividuals(Uri classUri);
    bool HasProperty(Uri uri);
    bool HasResource(Uri uri);
    bool HasResourceType(Uri uri, Uri classUri);
    bool HasIndividual(Uri uri);
    IDictionary<Uri, ISet<Uri>> RetrieveResourceStructure(Uri resource);
    IEnumerable<Uri> GetProductionGoals();
    IEnumerable<Uri> GetAgents();
    IEnumerable<Uri> GetHumans();
    IEnumerable<Uri> GetCobots();
    IEnumerable<Uri> GetFunctions();
    IEnumerable<Uri> GetFunctionsByAgent(Uri agent);
    IEnumerable<IDictionary<Uri, IEnumerable<ISet<Uri>>>> GetDecompositionGraph(Uri pGoal);
    IDictionary<Uri, ISet<Uri>> GetDependencyGraph(Uri resource);
    IEnumerable<IEnumerable<Uri>> GetProductionHierarchy(Uri pGoal);
    Uri GetResourceType(Uri resource);
    Uri GetFunctionTarget(Uri function);

    // TODO Define in domain and remove old models for agents, cobots and humans
    // IEnumerable<FunctionData> GetFunctionDataProperties(Uri func);
    // IEnumerable<ObjectData> GetFunctionObjectProperties(Uri func);
}