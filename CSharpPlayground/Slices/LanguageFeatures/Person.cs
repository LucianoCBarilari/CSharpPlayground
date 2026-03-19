namespace CSharpPlayground.Slices.LanguageFeatures
{
    internal class Person
    {
        public string Name
        {
            get => field;
            set =>
                field =
                    value
                    ?? throw new ArgumentNullException(
                        nameof(value),
                        "Name cannot be null"
                    );
        }
    }
}

