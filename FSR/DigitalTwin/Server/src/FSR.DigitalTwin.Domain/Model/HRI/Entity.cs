using System.ComponentModel.DataAnnotations;

namespace FSR.DigitalTwin.Domain.Model.HRI;

public abstract class Entity { 
    [Key] public required string Id { init; get; }
}