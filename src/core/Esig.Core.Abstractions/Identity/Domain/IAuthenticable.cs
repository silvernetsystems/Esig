namespace Esig.Core.Abstractions.Identity.Domain;

/// <summary>
/// Represents an entity that can authenticate to the system.
/// </summary>
public interface IAuthenticable
{
    /// <summary>
    /// Gets the username of the authenticable entity.
    /// </summary>
    /// <remarks>
    /// This method should return a unique value across all implementations
    /// of this interface, otherwise the database indexer might not work
    /// properly.
    /// </remarks>
    /// <returns>
    /// Username of the authenticable entity.
    /// </returns>
    public string Username { get; set; }

    /// <summary>
    /// Gets the password (hashed) of the authenticable entity.
    /// </summary>
    /// <returns>
    /// Password of the authenticable entity.
    /// </returns>
    string Password { get; set; }
}