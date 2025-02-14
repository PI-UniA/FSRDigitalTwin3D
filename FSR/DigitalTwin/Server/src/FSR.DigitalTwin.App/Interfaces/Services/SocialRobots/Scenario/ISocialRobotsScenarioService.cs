using FSR.DigitalTwin.Domain.Model.HRI;
using FSR.DigitalTwin.Domain.Model.HRI.Process;
using FSR.DigitalTwin.Domain.Model.HRI.Social;

namespace FSR.DigitalTwin.App.Interfaces.Services.SocialRobots.Scenario;

public interface ISocialRobotsScenarioService {

    public SocialScenario LoadScenario();
    public SocialParameter<T> SetParameterValue<T>(string parameterId, T value);
    public Task<bool> StartProcessAsync(string planId, CancellationToken cancellationToken = default);
    public bool StartProcess(string planId);

}