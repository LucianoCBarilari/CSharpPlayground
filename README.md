# CSharpPlayground

Practice repository for algorithms, data structures, design patterns, and assorted C# exercises.

## Structure
- `CSharpPlayground/Slices/Algorithms/` traversal and algorithm experiments
- `CSharpPlayground/Slices/Patterns/` design-pattern experiments (Composite)
- `CSharpPlayground/Slices/LanguageFeatures/` delegates, extensions, operators
- `CSharpPlayground/Slices/Exercises/` standalone practice classes
- `CSharpPlayground/Slices/StudentGrades/` student grade examples ready for tests
- `CSharpPlayground/Slices/TestingDojo/` QA/testing progression roadmap (xUnit first)
- `CSharpPlayground/Program.cs` slice router entrypoint

## Quick Conventions
- One file per exercise/class.
- Clear and consistent naming.
- Add a brief description above each exercise.

## Run by Slice
- `dotnet run --project CSharpPlayground -- language`
- `dotnet run --project CSharpPlayground -- patterns`
- `dotnet run --project CSharpPlayground -- algorithms`
- `dotnet run --project CSharpPlayground -- exercises`
- `dotnet run --project CSharpPlayground -- grades`
- `dotnet run --project CSharpPlayground -- testing`
