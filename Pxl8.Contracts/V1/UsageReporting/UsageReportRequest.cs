using System.Text.Json.Serialization;

namespace Pxl8.Contracts.V1.UsageReporting;

/// <summary>
/// Usage report from Data Plane to Control Plane
/// </summary>
/// <remarks>
/// Sent every 10-30 seconds (configurable flush interval)
/// Idempotent by report_id (duplicate reports ignored)
/// Spec: ARCHITECTURE_SPLIT.md - Usage Reporting Contract
/// </remarks>
public record UsageReportRequest
{
    /// <summary>
    /// Idempotency key (unique per report)
    /// </summary>
    /// <remarks>
    /// Control Plane deduplicates by report_id
    /// If same report_id received twice, second request is no-op
    /// </remarks>
    [JsonPropertyName("report_id")]
    public required Guid ReportId { get; init; }

    /// <summary>
    /// Data Plane identifier (e.g., "ru-central1-a")
    /// </summary>
    [JsonPropertyName("dataplane_id")]
    public required string DataplaneId { get; init; }

    /// <summary>
    /// Tenant that consumed resources
    /// </summary>
    [JsonPropertyName("tenant_id")]
    public required Guid TenantId { get; init; }

    /// <summary>
    /// Billing period GUID (NOT "YYYY-MM" string!)
    /// </summary>
    [JsonPropertyName("period_id")]
    public required Guid PeriodId { get; init; }

    /// <summary>
    /// Bandwidth consumed since last report (bytes)
    /// </summary>
    /// <remarks>
    /// Delta, not cumulative. Control Plane aggregates.
    /// </remarks>
    [JsonPropertyName("bandwidth_used_bytes")]
    public required long BandwidthUsedBytes { get; init; }

    /// <summary>
    /// Transforms consumed since last report (count)
    /// </summary>
    [JsonPropertyName("transforms_used")]
    public required int TransformsUsed { get; init; }

    /// <summary>
    /// Report generation timestamp (UTC)
    /// </summary>
    [JsonPropertyName("reported_at")]
    public required DateTimeOffset ReportedAt { get; init; }
}
