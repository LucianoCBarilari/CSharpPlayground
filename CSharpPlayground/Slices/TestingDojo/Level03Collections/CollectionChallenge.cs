using System.Linq;

namespace CSharpPlayground.Slices.TestingDojo.Level03Collections;

/// <summary>
/// Nivel 03: Gestión de Datos.
/// Listas, promedios y filtrado manual (sin abusar de lambdas complejas).
/// </summary>
public class CollectionChallenge
{
    // Calcular el promedio de una lista de notas (incluyendo los ceros).
    public double CalculateAverageScore(List<int> scores)
    {
        if (scores == null || !scores.Any()) return 0;

        return scores.Average();
    }

    // Buscar usuarios activos en una lista (Lógica procedimental clara).
    public List<string> GetActiveUsernames(List<UserAccount> accounts)
    {
        var result = new List<string>();
        if (accounts == null) return result;

        foreach (var account in accounts)
        {
            if (account.IsActive && !string.IsNullOrEmpty(account.Username))
            {
                result.Add(account.Username);
            }
        }

        result.Sort();
        return result;
    }

    // Detectar si hay duplicados en una lista de IDs.
    public bool HasDuplicateIds(List<int>? ids)
    {
        if (ids == null || ids.Count <= 1) return false;

        var seen = new HashSet<int>();
        foreach (int id in ids)
        {
            if (seen.Contains(id)) return true;
            seen.Add(id);
        }

        return false;
    }
}

public class UserAccount 
{
    public string Username { get; set; } = string.Empty;
    public bool IsActive { get; set; }
} 
