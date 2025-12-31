using System.Text.Json.Serialization;

namespace Pxl8.Contracts.V1.BudgetAllocation;

/// <summary>
/// Request to allocate budget lease from Control Plane
/// </summary>
/// <remarks>
/// Sent by Data Plane when budget is low (< 20% of granted)
/// Idempotent by request_id (same request_id returns same lease)
/// Spec: ARCHITECTURE_SPLIT.md - Budget Allocation Contract
/// </remarks>
public record BudgetAllocateRequest
{
    /// <summary>
    /// Idempotency key (unique per allocation attempt)
    /// </summary>
    /// <remarks>
    /// If Control Plane receives same request_id again, returns existing lease
    /// without creating new one
    /// </remarks>
    [JsonPropertyName("request_id")]
    public required Guid RequestId { get; init; }

    /// <summary>
    /// Data Plane identifier (e.g., "ru-central1-a")
    /// </summary>
    [JsonPropertyName("dataplane_id")]
    public required string DataplaneId { get; init; }

    /// <summary>
    /// Tenant requesting budget
    /// </summary>
    [JsonPropertyName("tenant_id")]
    public required Guid TenantId { get; init; }

    /// <summary>
    /// Billing period GUID (NOT "YYYY-MM" string!)
    /// </summary>
    /// <remarks>
    /// CRITICAL: period_id MUST be GUID, never "2024-12"
    /// See ARCHITECTURE_SPLIT.md - Terminology
    /// </remarks>
    [JsonPropertyName("period_id")]
    public required Guid PeriodId { get; init; }

    /// <summary>
    /// Requested bandwidth budget (bytes)
    /// </summary>
    /// <remarks>
    /// Control Plane will grant min(requested, available)
    /// </remarks>
    [JsonPropertyName("bandwidth_requested_bytes")]
    public required long BandwidthRequestedBytes { get; init; }

    /// <summary>
    /// Requested transform budget (count)
    /// </summary>
    [JsonPropertyName("transforms_requested")]
    public required int TransformsRequested { get; init; }
}
