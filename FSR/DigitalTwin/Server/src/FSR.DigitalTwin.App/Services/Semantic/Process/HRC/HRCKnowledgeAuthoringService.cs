using FSR.DigitalTwin.App.Interfaces.Services.Semantic.Process.HRC;
using FSR.DigitalTwin.Domain.Model.Process.HRC;
using Microsoft.Extensions.Logging;

namespace FSR.DigitalTwin.App.Services.Semantic.Process.HRC;

public class HRCKnowledgeAuthoringService
{
    private readonly IHRCKnowledgeService _knowledgeBase;
    private readonly ILogger<HRCKnowledgeAuthoringService> _logger;

    public HRCKnowledgeAuthoringService(IHRCKnowledgeService knowledgeBase, ILogger<HRCKnowledgeAuthoringService> logger)
    {
        _knowledgeBase = knowledgeBase ?? throw new ArgumentNullException(nameof(knowledgeBase));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public HRCModel CompileModel(long horizon)
    {
        HRCModel hrc = new(horizon);

        var humans = _knowledgeBase.GetHumans();
        foreach (var human in humans)
        {

        }
        return null;
    }
}