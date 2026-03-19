# Testing Dojo Test Workspace

This `docs/` folder contains documentation for the `TestingDojo` test workspace.

All `TestingDojo` test files currently live in the root of `tests/CSharpPlayground.Tests/`, not inside `docs/`.

## Documents
- `docs/TUTOR_GUIDELINES.md`: tutor role, response limits, and coaching rules.
- `docs/TESTING_DOJO_PROGRESS.md`: exercise progress by level.

## Current test files
- `../BasicsChallengeShould.cs`
- `../ValidationChallengeShould.cs`
- `../CollectionChallengeShould.cs`
- `../TextDateChallengeShould.cs`
- `../GreetingServiceShould.cs`
- `../CartServiceShould.cs`

## Naming
- Test file: `<ClassUnderTest>Tests.cs` or `<ClassUnderTest>Should.cs`
- Test method: `MethodName_Scenario_ExpectedBehavior`

## Minimum checklist per exercise
- Happy path covered.
- Boundary values covered.
- Invalid input covered.
- Deterministic behavior (no real clock/network/filesystem unless intentional).

## Notes
- Keep `docs/` for tutor rules, progress tracking, and workshop guidance.
- Keep exercise tests at the project root unless the suite grows enough to justify subfolders.
