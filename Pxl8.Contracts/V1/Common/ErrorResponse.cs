using System.Text.Json.Serialization;

namespace Pxl8.Contracts.V1.Common;

/// <summary>
/// Unified error response contract (all APIs)
/// </summary>
/// <remarks>
/// Used by: Data Gateway API, Control API, Portal API
/// Spec: ARCHITECTURE_SPLIT.md - Unified Error Contract
/// </remarks>
public record ErrorResponse
{
    /// <summary>
    /// Machine-readable error code (snake_case)
    /// </summary>
    /// <example>quota_exceeded</example>
    [JsonPropertyName("error_code")]
    public required string ErrorCode { get; init; }

    /// <summary>
    /// Human-readable error message
    /// </summary>
    /// <example>Bandwidth budget exhausted for current period</example>
    [JsonPropertyName("message")]
    public required string Message { get; init; }

    /// <summary>
    /// Additional context-specific details
    /// </summary>
    [JsonPropertyName("details")]
    public Dictionary<string, object>? Details { get; init; }

    /// <summary>
    /// Distributed tracing ID for correlation
    /// </summary>
    [JsonPropertyName("trace_id")]
    public required Guid TraceId { get; init; }

    /// <summary>
    /// Error timestamp (ISO 8601 UTC)
    /// </summary>
    [JsonPropertyName("timestamp")]
    public required DateTimeOffset Timestamp { get; init; }
}
