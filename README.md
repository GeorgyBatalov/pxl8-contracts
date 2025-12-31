# PXL8 Contracts

**Version:** v1.0.0
**Target:** .NET 9.0
**Purpose:** Shared DTOs and API contracts for Data/Control Plane communication

---

## 📦 What's Inside

This library contains:

- **DTOs**: Data Transfer Objects for inter-plane communication
- **API Contracts**: Request/response models for all APIs
- **Versioning**: Semantic versioning for contract evolution
- **Validation**: Shared validation logic

---

## 🏗️ Structure

```
Pxl8.Contracts/
├── V1/                          # Version 1 contracts
│   ├── PolicySnapshot/          # Policy snapshot DTOs
│   │   ├── PolicySnapshotDto.cs
│   │   ├── TenantPolicyDto.cs
│   │   └── DomainPolicyDto.cs
│   ├── BudgetAllocation/        # Budget allocation DTOs
│   │   ├── BudgetAllocateRequest.cs
│   │   ├── BudgetAllocateResponse.cs
│   │   └── BudgetLeaseDto.cs
│   ├── UsageReporting/          # Usage reporting DTOs
│   │   ├── UsageReportDto.cs
│   │   └── UsageLineItemDto.cs
│   └── Common/                  # Common DTOs
│       ├── ErrorResponse.cs
│       └── PaginationDto.cs
├── Abstractions/                # Interfaces
│   └── IVersioned.cs
└── Versioning/                  # Version management
    └── ContractVersion.cs
```

---

## 🔄 Versioning Strategy

**Semantic Versioning:**
- Major: Breaking changes (v1 → v2)
- Minor: Backward-compatible additions
- Patch: Bug fixes

**API Versioning:**
- Each DTO namespace includes version (V1, V2, etc.)
- Controllers specify version in route: `/api/v1/...`
- Old versions supported for 6 months after deprecation

---

## 📋 Contract Principles

1. **Immutability**: DTOs are immutable (init-only properties)
2. **Validation**: Use DataAnnotations for basic validation
3. **Documentation**: XML comments on all public types
4. **Nullable**: Explicit nullable reference types
5. **Serialization**: Optimized for System.Text.Json

---

## 🧪 Usage Example

```csharp
using Pxl8.Contracts.V1.PolicySnapshot;

var snapshot = new PolicySnapshotDto
{
    SnapshotId = Guid.NewGuid(),
    Version = 1,
    GeneratedAt = DateTimeOffset.UtcNow,
    Tenants = new[] { ... }
};
```

---

## 🔗 Dependencies

**None** - this library has zero external dependencies (except .NET 9.0 BCL)

**Why?** To ensure Data Plane and Control Plane can evolve independently.

---

## 📝 Related Documents

- [ARCHITECTURE_SPLIT.md](../ARCHITECTURE_SPLIT.md) - Split plane architecture
- [BUDGET_ALGORITHM.md](../BUDGET_ALGORITHM.md) - Budget allocation algorithm
- [ROADMAP.md](../ROADMAP.md) - Implementation roadmap

---

**Last Updated:** 31 December 2024 (v1.0.0)
