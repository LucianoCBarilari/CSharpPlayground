# EF Core Practice Notes

Use this level when you want integration-style tests.

## Target setup
- Add `Microsoft.EntityFrameworkCore`
- Add provider:
  - `Microsoft.EntityFrameworkCore.InMemory` for fast isolated tests
  - or `Microsoft.EntityFrameworkCore.Sqlite` for more realistic SQL behavior

## Recommended test focus
- Mapping and key constraints.
- Query behavior against `StudentQueries.GetHonorRoll`.
- CRUD repository flows with isolated database per test.

## Pitfalls to validate
- InMemory provider behavior differs from relational providers.
- Ordering and case sensitivity can vary by provider.
- Shared database names can leak state between tests.
