# Testing Dojo Test Workspace

Use this folder for all tests related to the `TestingDojo` slice.

## Documents
- `docs/TUTOR_GUIDELINES.md`: tutor role, response limits, and coaching rules.
- `docs/TESTING_DOJO_PROGRESS.md`: exercise progress by level.

## Naming
- Test file: `<ClassUnderTest>Tests.cs` or `<ClassUnderTest>Should.cs`
- Test method: `MethodName_Scenario_ExpectedBehavior`

## Minimum checklist per exercise
- Happy path covered.
- Boundary values covered.
- Invalid input covered.
- Deterministic behavior (no real clock/network/filesystem unless intentional).

## Suggested organization
- `Basics/`
- `Validation/`
- `TheoryData/`
- `Mocks/`
- `FluentAssertions/`
- `Repository/`
- `EfCoreIntegration/`
