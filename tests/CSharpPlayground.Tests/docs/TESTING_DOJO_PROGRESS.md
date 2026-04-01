# Testing Dojo Progress

## Level 1
- [x] BasicsChallenge.CalculateDiscount
- [x] BasicsChallenge.IsLeapYear
- [x] BasicsChallenge.CelsiusToFahrenheit

## Level 2
- [x] ValidationChallenge.IsValidUsername
- [x] ValidationChallenge.ValidateOrder
- [x] ValidationChallenge.IsSecurePassword

## Level 3
- [x] CollectionChallenge.CalculateAverageScore
- [x] CollectionChallenge.GetActiveUsernames
- [x] CollectionChallenge.HasDuplicateIds

## Level 4
- [x] TextDateChallenge.Slugify
- [x] TextDateChallenge.NextBusinessDay
- [x] GreetingService.BuildGreeting

## Level 5
- [x] CartService.AddItem
- [x] CartService.RemoveItem
- [x] CartService.ApplyPercentDiscount
- [x] CartService.GetSubtotal
- [ ] CartService.GetTotal
- [ ] CartService.Clear

## Level 6
- [~] InvoiceNotifier.NotifyOverdueInvoices
- [x] verify interaction count and arguments on collaborators
- [x] paid invoice is skipped
- [x] unpaid overdue invoice is notified
- [x] below-threshold invoice is skipped
- [x] exact-threshold invoice is notified
- [ ] null invoices throws `ArgumentNullException`
- [ ] threshold `0` throws `ArgumentOutOfRangeException`
- [ ] negative threshold throws `ArgumentOutOfRangeException`

## Level 7
- [ ] ReportAssembler.BuildCourseReport
- focus on object graph assertions and collection ordering

## Level 8
- [ ] StudentService.EnrollAsync
- [ ] StudentService.AssignGradeAsync

## Level 9
- [ ] StudentQueries.GetHonorRoll
- later run against EF Core provider when packages are added
