using Domain.Interfaces;

namespace Domain.Entities;

public class AccessAndRefreshToken : ITenantEntity
{
    public Guid Id { get; set; }
    public required Guid TenantId { get; set; }
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
    public required Guid UserId { get; set; }
    public User User { get; set; } = null!;
    
    public DeviceType DeviceType { get; set; } = DeviceType.WEB;
    
    public bool IsRevoked { get; set; } = false;
    public DateTime TokenExpiresAt { get; set; }
    public DateTime RefreshTokenExpiresAt { get; set; }

    public bool IsExpired => DateTime.UtcNow >= RefreshTokenExpiresAt;
    public bool IsActive => !IsRevoked && !IsExpired;
}

public enum DeviceType
{
    WEB,
    MOBILE
}
public static class DeviceTypeExtensions
{
    /// <summary>
    /// Checks if the provided string matches a valid DeviceType.
    /// </summary>
    public static bool TryThisTypeAndMatch(this string deviceType)
    {
        // Enum.TryParse handles the conversion and returns true if it exists.
        // ignoreCase: true allows "web" to match DeviceType.WEB.
        return Enum.TryParse(deviceType, true, out DeviceType _);
    }
}