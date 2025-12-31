using System.Text.Json.Serialization;

namespace Pxl8.Contracts.V1.BudgetAllocation;

/// <summary>
/// Response from Control Plane with budget lease
/// </summary>
/// <remarks>
/// Control Plane allocates budget lease with 5-minute TTL
/// ONE active lease per (tenant_id, period_id, dataplane_id) tuple
/// Spec: ARCHITECTURE_SPLIT.md - Budget Allocation Contract
/// </remarks>
public record BudgetAllocateResponse
{
    /// <summary>
    /// Unique lease identifier
    /// </summary>
    [JsonPropertyName("lease_id")]
    public required Guid LeaseId { get; init; }

    /// <summary>
    /// Granted bandwidth budget (bytes)
    /// </summary>
    /// <remarks>
    /// May be less than requested if not enough quota available
    /// = min(requested, tenant_limit - consumed - leased_active)
    /// </remarks>
    [JsonPropertyName("bandwidth_granted_bytes")]
    public required long BandwidthGrantedBytes { get; init; }

    /// <summary>
    /// Granted transform budget (count)
    /// </summary>
    [JsonPropertyName("transforms_granted")]
    public required int TransformsGranted { get; init; }

    /// <summary>
    /// Lease grant timestamp (UTC)
    /// </summary>
    [JsonPropertyName("granted_at")]
    public required DateTimeOffset GrantedAt { get; init; }

    /// <summary>
    /// Lease expiry timestamp (UTC)
    /// </summary>
    /// <remarks>
    /// Typically granted_at + 5 minutes (TTL)
    /// Data Plane MUST treat expired lease as zero budget (hard cutoff)
    /// </remarks>
    [JsonPropertyName("expires_at")]
    public required DateTimeOffset ExpiresAt { get; init; }
}
