namespace CSharpPlayground.Slices.TestingDojo.Level05Stateful;

public class CartService
{
    private readonly Dictionary<string, CartLine> lines = new(StringComparer.OrdinalIgnoreCase);
    private decimal discountRate;

    public IReadOnlyCollection<CartLine> Lines => lines.Values.ToList();

    public void AddItem(string sku, int quantity, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(sku))
            throw new ArgumentException("SKU is required.", nameof(sku));
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        if (unitPrice < 0)
            throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price cannot be negative.");

        var normalizedSku = sku.Trim();
        if (lines.TryGetValue(normalizedSku, out var currentLine))
        {
            lines[normalizedSku] = currentLine with
            {
                Quantity = currentLine.Quantity + quantity,
                UnitPrice = unitPrice
            };
            return;
        }

        lines[normalizedSku] = new CartLine(normalizedSku, quantity, unitPrice);
    }

    public void RemoveItem(string sku)
    {
        if (string.IsNullOrWhiteSpace(sku))
            throw new ArgumentException("SKU is required.", nameof(sku));

        if (!lines.Remove(sku.Trim()))
            throw new InvalidOperationException("SKU not found in cart.");
    }

    public void ApplyPercentDiscount(decimal rate)
    {
        if (rate < 0m || rate > 0.80m)
            throw new ArgumentOutOfRangeException(nameof(rate), "Discount must be between 0 and 0.80.");

        discountRate = rate;
    }

    public decimal GetSubtotal() => lines.Values.Sum(line => line.Quantity * line.UnitPrice);

    public decimal GetTotal()
    {
        var subtotal = GetSubtotal();
        return subtotal - subtotal * discountRate;
    }

    public void Clear()
    {
        lines.Clear();
        discountRate = 0m;
    }
}

public sealed record CartLine(string Sku, int Quantity, decimal UnitPrice);
