namespace CSharpPlayground.Slices.LanguageFeatures
{
    public delegate void ToCsv(int[] numbers, out string result);
    public class DelegateExample
    {
        public ToCsv ConvertToCsv = (numbers, out result) => result = string.Join(",", numbers);
    }
    
}

