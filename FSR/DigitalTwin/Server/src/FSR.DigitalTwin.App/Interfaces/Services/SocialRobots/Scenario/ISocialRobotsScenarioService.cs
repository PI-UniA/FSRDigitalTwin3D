using FSR.DigitalTwin.Domain.Model.HRI;
using FSR.DigitalTwin.Domain.Model.HRI.Social;

namespace FSR.DigitalTwin.App.Interfaces.Services.SocialRobots.Scenario;

public interface ISocialRobotsScenarioService {

    public SocialScenario CreateSocialScenario();
    public SocialParameter<T> SetParameterValue<T>(T value);
    public Task<bool> RunPlanAsync(string planId, CancellationToken cancellationToken = default);
    public bool RunPlan(string planId);

}