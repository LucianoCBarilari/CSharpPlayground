namespace CSharpPlayground.Slices.TestingDojo.Level02Validation;

public sealed class ValidationException(string message) : Exception(message);

/// <summary>
/// Nivel 02: El Arte de Decir "No".
/// Validaciones de entrada y manejo de excepciones de dominio.
/// </summary>
public sealed class ValidationChallenge
{
    // Validar un nombre de usuario: 5-20 caracteres, sin espacios, solo letras y números.
    public bool IsValidUsername(string? username)
    {
        if (string.IsNullOrWhiteSpace(username)) 
            return false;

        if (username.Length < 5 || username.Length > 20) 
                return false;

        foreach (char c in username)
        {
            if (!char.IsLetterOrDigit(c)) 
            return false;
        }

        return true;
    }

    // Lógica de pedidos: No se aceptan pedidos de más de 10 ítems si el total es menor a 50$ (spam protection).
    public void ValidateOrder(decimal totalAmount, int itemCount)
    {
        if (totalAmount < 0) 
            throw new ArgumentOutOfRangeException(nameof(totalAmount), "El total no puede ser negativo.");

        if (itemCount <= 0)
            throw new ArgumentException("El pedido debe tener al menos un ítem.");

        if (itemCount > 10 && totalAmount < 50)
        {
            throw new ValidationException("Pedidos grandes deben superar el mínimo de 50$.");
        }
    }

    // Verificación de contraseñas básica (sin regex pesados, lógica pura).
    public bool IsSecurePassword(string password)
    {
        if (string.IsNullOrEmpty(password) || password.Length < 8) return false;

        bool hasUpper = false;
        bool hasLower = false;
        bool hasDigit = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c)) hasUpper = true;
            if (char.IsLower(c)) hasLower = true;
            if (char.IsDigit(c)) hasDigit = true;
        }

        return hasUpper && hasLower && hasDigit;
    }
}
