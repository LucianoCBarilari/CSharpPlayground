namespace CSharpPlayground.Slices.TestingDojo.Level06Mocks;

public interface INotificationGateway
{
    void Send(string recipient, string subject, string body);
}

public interface IAuditSink
{
    void Write(string message);
}

public sealed class InvoiceNotifier(
    INotificationGateway notificationGateway,
    IAuditSink auditSink,
    DateOnly today
)
{
    public int NotifyOverdueInvoices(IEnumerable<Invoice> invoices, int overdueDaysThreshold)
    {
        ArgumentNullException.ThrowIfNull(invoices);
        if (overdueDaysThreshold < 1)
            throw new ArgumentOutOfRangeException(
                nameof(overdueDaysThreshold),
                "Threshold must be greater than zero."
            );

        var sent = 0;
        foreach (var invoice in invoices)
        {
            if (invoice.Paid)
                continue;

            var overdueDays = today.DayNumber - invoice.DueDate.DayNumber;
            if (overdueDays < overdueDaysThreshold)
                continue;

            notificationGateway.Send(
                invoice.CustomerEmail,
                $"Invoice {invoice.InvoiceNumber} overdue",
                $"Invoice is overdue by {overdueDays} day(s)."
            );

            auditSink.Write($"Notified {invoice.CustomerEmail} for invoice {invoice.InvoiceNumber}.");
            sent++;
        }

        return sent;
    }
}

public sealed record Invoice(
    string InvoiceNumber,
    string CustomerEmail,
    DateOnly DueDate,
    bool Paid
);
