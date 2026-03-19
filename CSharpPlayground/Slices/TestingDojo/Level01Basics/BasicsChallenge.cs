namespace CSharpPlayground.Slices.TestingDojo.Level01Basics;

/// <summary>
/// Nivel 01: Lógica Fundamental.
/// Aquí practicamos la base: comparaciones, rangos y lógica condicional simple.
/// </summary>
public sealed class BasicsChallenge
{
    // Lógica de descuentos clara: VIPs tienen 20%, compras > 100 tienen 10%, no acumulables.
    public decimal CalculateDiscount(decimal price, bool isVip)
    {
        if (price <= 0) return 0;

        if (isVip)
        {
            return price * 0.20m;
        }

        if (price > 100)
        {
            return price * 0.10m;
        }

        return 0;
    }

    // Una lógica clásica pero con trampas de años bisiestos.
    public bool IsLeapYear(int year)
    {
        if (year < 1) return false;

        if (year % 400 == 0) return true;
        if (year % 100 == 0) return false;
        if (year % 4 == 0) return true;

        return false;
    }

    // Conversión de temperatura. Ideal para testear precisión de doubles.
    public double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }
}
