namespace CSharpPlayground.Slices.LanguageFeatures
{
    public static class MyExtensions
    {
        extension(IEnumerable<int> numbers)
        {
            public string Csv => string.Join(",", numbers);

            public IEnumerable<int> GetEven()
            {
                foreach (var number in numbers)
                {
                    if (number % 2 == 0)
                    {
                        yield return number;
                    }
                }
            }
            public IEnumerable<int> GetOdd()
            {
                foreach (var number in numbers)
                {
                    if (number % 2 != 0)
                    {
                        yield return number;
                    }
                }
            }
        }
    }
}

