namespace Esig.Core.Abstractions;

/// <summary>
/// Represents an application entity.
/// </summary>
public interface IEntity
{ 
    /// <summary>
    /// Id of the entity.
    /// </summary>
    string Id { get; set; }
}