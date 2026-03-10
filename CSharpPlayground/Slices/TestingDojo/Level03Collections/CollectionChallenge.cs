namespace CSharpPlayground.Slices.TestingDojo.Level03Collections;

/// <summary>
/// Nivel 03: Gestión de Datos.
/// Listas, promedios y filtrado manual (sin abusar de lambdas complejas).
/// </summary>
public sealed class CollectionChallenge
{
    // Calcular el promedio de una lista de notas, ignorando los ceros (ausentes).
    public double CalculateAverageScore(List<int> scores)
    {
        if (scores == null || scores.Count == 0) return 0;

        double sum = 0;
        int count = 0;

        foreach (int score in scores)
        {
            if (score > 0)
            {
                sum += score;
                count++;
            }
        }

        if (count == 0) return 0;

        return sum / count;
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
    public bool HasDuplicateIds(List<int> ids)
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

public sealed record UserAccount(string Username, bool IsActive);
