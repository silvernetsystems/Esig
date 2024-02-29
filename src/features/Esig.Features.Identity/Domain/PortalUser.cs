using Esig.Core.Abstractions;
using Esig.Core.Abstractions.Identity.Domain;

namespace Esig.Features.Identity.Domain;

/// <summary>
/// A user that can log in and use the back-end portal.
/// These could be agents, employees, contractors, etc...
/// </summary>
public class PortalUser : IEntity, IAuthenticable
{
    /// <inheritdoc />
    public string Id { get; set; } = null!;
    
    /// <summary>
    /// Name of the portal user.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Role of the portal user.
    /// CEO, Consultant, Director, Specialist, Agent, etc...
    /// </summary>
    public string Role { get; set; } = string.Empty;

    /// <summary>
    /// Role classification.
    /// Agent, Agency, Employee, etc...
    /// </summary>
    public string Classification { get; set; } = string.Empty;
    
    /// <summary>
    /// ID of the portal user, this portal user reports to.
    /// </summary>
    public string ReportsTo { get; set; } = string.Empty;
    
    /// <inheritdoc />
    public string Username { get; set; } = string.Empty;

    /// <inheritdoc />
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Indicates whether the user is locked out of the system.
    /// If ture, the user cannot log in, otherwise the user is active.
    /// </summary>
    public bool IsLocked { get; set; }

    /// <summary>
    /// A list of permission.
    /// </summary>
    public List<string> Permissions { get; set; } = new();
}