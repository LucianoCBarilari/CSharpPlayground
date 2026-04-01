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
- `../InvoiceNotifierShould.cs`

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

## Current dojo status
- Level 1 to Level 3: covered with tests.
- Level 4: `Slugify`, `NextBusinessDay`, and `GreetingService.BuildGreeting` covered.
- Level 5: `AddItem`, `RemoveItem`, `ApplyPercentDiscount`, and `GetSubtotal` covered. `GetTotal` and `Clear` still pending.
- Level 6: `InvoiceNotifier.NotifyOverdueInvoices` has an initial suite covering paid, unpaid/overdue, below-threshold, and exact-threshold paths. Guard-clause tests are still pending.

## Next work
- Add `CartService.GetTotal` tests.
- Add `CartService.Clear` tests.
- Complete `InvoiceNotifier.NotifyOverdueInvoices` guard-clause coverage:
- `null` invoices should throw `ArgumentNullException`.
- threshold `0` should throw `ArgumentOutOfRangeException`.
- negative threshold should throw `ArgumentOutOfRangeException`.
