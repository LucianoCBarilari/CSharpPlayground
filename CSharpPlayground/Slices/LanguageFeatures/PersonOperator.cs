namespace CSharpPlayground.Slices.LanguageFeatures;

public class PersonOperator
{
    public int Age { get; set; }
    public string Name { get; set; }

    public PersonOperator(int age, string name)
    {
        Age = age;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Name} - {Age}";
    }

    public static PersonOperator operator +(PersonOperator p1, int age)
    {
        return new PersonOperator(p1.Age + age, p1.Name);
    }
}
