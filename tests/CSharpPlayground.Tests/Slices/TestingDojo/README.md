# Testing Dojo - Test Workspace

Use this folder for all tests related to the `TestingDojo` slice.

## Regla de Oro del Tutor
- **No resultados:** El tutor nunca proporcionará el código final ni las respuestas directas.
- **Acompañamiento:** El tutor actuará como guía, señalando conceptos, trampas lógicas y mejores prácticas.
- **Aprendizaje Activo:** El estudiante es el único responsable de escribir y validar el código para asegurar la asimilación de conceptos.

## Naming
- Test file: `<ClassUnderTest>Tests.cs`
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
