using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Interfaces.Services.SocialRobots.Scenario;
using FSR.DigitalTwin.Domain.Model.HRI;
using FSR.DigitalTwin.Domain.Model.HRI.Social;
using Microsoft.Extensions.Logging;

namespace FSR.DigitalTwin.App.Services.SocialRobots.Scenario;

public class SohoScenarioService : ISocialRobotsScenarioService
{

    private readonly ITripletServer _tripletServer;
    private readonly ISparqlServer _sparqlServer;
    private readonly ILogger<SohoScenarioService> _logger;
    private SocialScenario? _scenario;

    public SohoScenarioService(ITripletServer tripletServer, ISparqlServer sparqlServer, ILogger<SohoScenarioService> logger) {
        _tripletServer = tripletServer ?? throw new NullReferenceException(nameof(tripletServer));
        _sparqlServer = sparqlServer ?? throw new NullReferenceException(nameof(sparqlServer));
        _logger = logger ?? throw new NullReferenceException(nameof(logger));
        _scenario = null;
    }

    public SocialScenario LoadScenario()
    {
        throw new NotImplementedException();
    }

    public SocialParameter<T> SetParameterValue<T>(string parameterId, T value)
    {
        throw new NotImplementedException();
    }

    public bool StartProcess(string planId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> StartProcessAsync(string planId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}