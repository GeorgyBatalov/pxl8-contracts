using System.Text.Json.Serialization;

namespace Pxl8.Contracts.V1.UsageReporting;

/// <summary>
/// Response from Control Plane after processing usage report
/// </summary>
/// <remarks>
/// Returns aggregate usage across all Data Planes for tenant/period
/// Data Plane can use this for local validation (optional)
/// </remarks>
public record UsageReportResponse
{
    /// <summary>
    /// Report accepted flag
    /// </summary>
    /// <remarks>
    /// true = report processed
    /// false = duplicate report_id (already processed, idempotent no-op)
    /// </remarks>
    [JsonPropertyName("accepted")]
    public required bool Accepted { get; init; }

    /// <summary>
    /// Total bandwidth consumed across all Data Planes (bytes)
    /// </summary>
    /// <remarks>
    /// Aggregate for (tenant_id, period_id) across all dataplanes
    /// Updated after accepting this report
    /// </remarks>
    [JsonPropertyName("total_bandwidth_bytes")]
    public required long TotalBandwidthBytes { get; init; }

    /// <summary>
    /// Total transforms consumed across all Data Planes (count)
    /// </summary>
    [JsonPropertyName("total_transforms")]
    public required int TotalTransforms { get; init; }
}
