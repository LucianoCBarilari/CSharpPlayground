# Testing Dojo Plan (2026)

This slice is for QA-focused unit testing practice with progressive complexity.

## Workspace docs
- Test workspace overview: `tests/CSharpPlayground.Tests/Slices/TestingDojo/README.md`
- Tutor guidance: `tests/CSharpPlayground.Tests/Slices/TestingDojo/docs/TUTOR_GUIDELINES.md`
- Exercise progress tracker: `tests/CSharpPlayground.Tests/Slices/TestingDojo/docs/TESTING_DOJO_PROGRESS.md`

## Rules of the game
- Keep production code minimal and explicit.
- Keep tests readable with clear naming.
- Prefer deterministic tests (no random, no real time, no external IO).
- One behavioral assertion per test when possible.
- If you write boilerplate, keep going and improve later.

## Suggested progression

1. Tiny pure functions
- Example problems:
  - `BasicsChallenge.AreEqual(int left, int right)`
  - `BasicsChallenge.IsEven(int value)`
  - `BasicsChallenge.MaxOfTwo(int left, int right)`
- Objective:
  - Use `Fact`
  - Use AAA pattern
  - Apply meaningful test names

2. Validation and exceptions
- Example problems:
  - `ValidationChallenge.NormalizeEmail(string email)`
  - `ValidationChallenge.EnsureAgeWithinRange(int age, int minAge, int maxAge)`
  - `ValidationChallenge.CalculateDiscountRate(decimal totalAmount, int loyaltyYears)`
- Objective:
  - Use `Assert.Throws`
  - Cover boundaries and invalid cases

3. Data-driven tests
- Example problems:
  - `CollectionChallenge.GetEvenNumbers(IEnumerable<int> source)`
  - `CollectionChallenge.TopScores(IEnumerable<int> scores, int count)`
  - `CollectionChallenge.GroupByPassStatus(IEnumerable<decimal> scores, decimal passingScore)`
- Objective:
  - Use `Theory`, `InlineData`, `MemberData`

4. Stateful behavior
- Example problems:
  - `CartService.AddItem(...)`
  - `CartService.RemoveItem(...)`
  - `CartService.ApplyPercentDiscount(decimal rate)`
- Objective:
  - Control setup per test
  - Avoid cross-test shared state

5. Mocking collaborators
- Example problems:
  - `InvoiceNotifier.NotifyOverdueInvoices(...)`
  - collaborators: `INotificationGateway`, `IAuditSink`
- Objective:
  - Verify collaborator interaction
  - Isolate business logic from infrastructure

6. FluentAssertions
- Objective:
  - Replace opaque assertions with expressive checks
  - Use equivalence assertions for `CourseReport` and nested `StudentResult`

7. Repository pattern
- Example problems:
  - `StudentService` + `IStudentRepository`
  - `InMemoryStudentRepository` for quick feedback
- Objective:
  - Unit test service rules with mocked repository
  - Keep repository integration concerns outside service tests

8. EF Core integration tests
- Example problems:
  - Query tests on `StudentQueries.GetHonorRoll(...)`
  - Later plug real EF Core provider using `Level09EfCoreReady/EFCORE_NOTES.md`
- Objective:
  - Integration tests for data access only
  - Use isolated DB per test (InMemory or SQLite in-memory)
  - Validate mappings and query expectations

## Delivery standard for each level
- `Production`:
  - Simple API with clear names and input guards.
- `Tests`:
  - Happy path + edge cases + invalid path.
- `Review`:
  - Identify duplication, naming issues, and flaky risks.
