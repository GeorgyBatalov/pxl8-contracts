using System.Text.Json.Serialization;

namespace Pxl8.Contracts.V1.PolicySnapshot;

/// <summary>
/// Single tenant policy (part of PolicySnapshot)
/// </summary>
public record TenantPolicyDto
{
    /// <summary>
    /// Tenant unique identifier
    /// </summary>
    [JsonPropertyName("tenant_id")]
    public required Guid TenantId { get; init; }

    /// <summary>
    /// Tenant status (active | suspended | deleted)
    /// </summary>
    /// <remarks>
    /// Data Plane MUST return 403 Forbidden if status != "active"
    /// </remarks>
    [JsonPropertyName("status")]
    public required string Status { get; init; }

    /// <summary>
    /// Plan code (free | starter | pro | enterprise)
    /// </summary>
    [JsonPropertyName("plan_code")]
    public required string PlanCode { get; init; }

    /// <summary>
    /// Quota limits for current billing period
    /// </summary>
    [JsonPropertyName("quotas")]
    public required QuotasDto Quotas { get; init; }

    /// <summary>
    /// Verified domains (for delivery restriction)
    /// </summary>
    [JsonPropertyName("domains")]
    public required IReadOnlyList<DomainDto> Domains { get; init; }

    /// <summary>
    /// Active API keys (for authentication)
    /// </summary>
    [JsonPropertyName("api_keys")]
    public required IReadOnlyList<ApiKeyDto> ApiKeys { get; init; }
}

/// <summary>
/// Quota limits for tenant
/// </summary>
public record QuotasDto
{
    /// <summary>
    /// Bandwidth limit per billing period (bytes)
    /// </summary>
    [JsonPropertyName("bandwidth_limit_bytes")]
    public required long BandwidthLimitBytes { get; init; }

    /// <summary>
    /// Transform limit per billing period (count)
    /// </summary>
    [JsonPropertyName("transforms_limit")]
    public required int TransformsLimit { get; init; }

    /// <summary>
    /// Storage limit (total, not per period) (bytes)
    /// </summary>
    [JsonPropertyName("storage_limit_bytes")]
    public required long StorageLimitBytes { get; init; }

    /// <summary>
    /// Domains limit (total, not per period) (count)
    /// </summary>
    [JsonPropertyName("domains_limit")]
    public required int DomainsLimit { get; init; }
}

/// <summary>
/// Domain configuration
/// </summary>
public record DomainDto
{
    /// <summary>
    /// Domain name (e.g., "example.com")
    /// </summary>
    [JsonPropertyName("domain")]
    public required string Domain { get; init; }

    /// <summary>
    /// Verification status
    /// </summary>
    /// <remarks>
    /// Data Plane MUST only deliver images for verified=true domains
    /// </remarks>
    [JsonPropertyName("verified")]
    public required bool Verified { get; init; }
}

/// <summary>
/// API key configuration (for fast validation)
/// </summary>
public record ApiKeyDto
{
    /// <summary>
    /// API key prefix (first 8 chars, e.g., "pxl8_abc")
    /// </summary>
    /// <remarks>
    /// Used for logging/debugging only
    /// </remarks>
    [JsonPropertyName("key_prefix")]
    public required string KeyPrefix { get; init; }

    /// <summary>
    /// HMAC-SHA256 of full API key (for fast validation)
    /// </summary>
    /// <remarks>
    /// Data Plane validates by computing HMAC(received_key, server_pepper)
    /// and comparing with this value (constant-time comparison)
    /// </remarks>
    [JsonPropertyName("key_hmac")]
    public required string KeyHmac { get; init; }

    /// <summary>
    /// API key status (active | revoked)
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; init; }
}
