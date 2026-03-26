using CSharpPlayground.Slices.TestingDojo.Level06Mocks;
using Moq;
using Xunit;

namespace CSharpPlayground.Tests;


public class InvoiceNotifierShould
{
    [Fact]
    public void NotifyOverdueInvoices_WhenInvoiceIsPaid_DoesNotSendNotification()
    {
         Mock<INotificationGateway> mockNotificationGateway = new();
         Mock<IAuditSink> mockAuditSink = new();
         var today = new DateOnly(2026, 3, 25);

        InvoiceNotifier invoiceNotifier = new(
            mockNotificationGateway.Object,
            mockAuditSink.Object,
            today);

        List<Invoice> invoices = new()
        {
            new("inv-001","customer@some.com", new DateOnly(2026, 3, 24),true)
        };

        var result = invoiceNotifier.NotifyOverdueInvoices(invoices,1);

        Assert.Equal(0, result);

    }
    [Fact]
    public void NotifyOverdueInvoices_WhenInvoiceIsUnpaidAndOverdue_ReturnsOneAndNotifiesDependencies()
    {
        Mock<INotificationGateway> mockNotificationGateway = new();
        Mock<IAuditSink> mockAuditSink = new();
        var today = new DateOnly(2026, 3, 26);
        InvoiceNotifier invoiceNotifier = new(
            mockNotificationGateway.Object,
            mockAuditSink.Object,
            today);

         List<Invoice> invoices = new()
        {
            new("inv-001","customer@some.com", new DateOnly(2026, 3, 24),false)
        };

        var result = invoiceNotifier.NotifyOverdueInvoices(invoices,1);

        mockNotificationGateway.Verify(
      x => x.Send(
          "customer@some.com",
          "Invoice inv-001 overdue",
          "Invoice is overdue by 2 day(s)."),
      Times.Once);

  mockAuditSink.Verify(
      x => x.Write("Notified customer@some.com for invoice inv-001."),
      Times.Once);

        Assert.Equal(1, result);
    }

    [Theory]
    [MemberData(nameof(InvoicesCases))]
    public void NotifyOverdueInvoices_VariousScenarios_ReturnsExpectedCount(
        string invoiceNumber,
        string customerEmail,
        DateOnly dueDate,
        bool paid,
        int overdueDays,
        int expectedResult)
    {
        Mock<INotificationGateway> mockNotificationGateway = new();
        Mock<IAuditSink> mockAuditSink = new();
        var today = new DateOnly(2026, 3, 26);

        InvoiceNotifier invoiceNotifier = new(
            mockNotificationGateway.Object,
            mockAuditSink.Object,
            today);

        List<Invoice> invoices = new()
        {
            new(invoiceNumber, customerEmail, dueDate, paid)
        };

        var result = invoiceNotifier.NotifyOverdueInvoices(invoices, overdueDays);

        Assert.Equal(expectedResult, result);

        mockNotificationGateway.Verify(
            x => x.Send(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Exactly(expectedResult));

        mockAuditSink.Verify(
            x => x.Write(It.IsAny<string>()),
            Times.Exactly(expectedResult));
    }
    public static TheoryData<string, string, DateOnly, bool, int, int> InvoicesCases => new()
    {
        { "inv-001", "customer@some.com", new DateOnly(2026, 3, 24), false, 1, 1 },
        { "inv-001", "customer@some.com", new DateOnly(2026, 3, 24), true, 1, 0 },
        { "inv-001", "customer@some.com", new DateOnly(2026, 3, 25), false, 2, 0 },
        { "inv-001", "customer@some.com", new DateOnly(2026, 3, 24), false, 2, 1 }
    };
  }
