namespace FSR.DigitalTwin.Domain.Model.HRI.Social.Attribute;

/// <summary>
/// Represents a collection of socially relevant entities with corresponding describing parameters.
/// 
/// E.g. objects in a human's focus could be such a collection. These could be indicated by parameters such as
/// human gaze, the human agent's position or the list of objects the agent is required to or currently interacting with.
/// </summary>
public class SocialEntityCollection : SocialAttribute {
    public Dictionary<Entity, List<SocialParameter>> Entities { get; } = [];

    public SocialEntityCollection(Dictionary<Entity, List<SocialParameter>>? entities = null) {
        Entities = entities ?? [];
        foreach (Entity entity in Entities.Keys) {
            foreach (SocialParameter parameter in Entities[entity]) {
                if (!Parameters.Contains(parameter)) {
                    Parameters.Add(parameter);
                }
            }
        }
    }
}