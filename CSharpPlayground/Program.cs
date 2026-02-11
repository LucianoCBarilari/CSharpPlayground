using CSharpPlayground.Others;
namespace CSharpPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            // The following code demonstrates the use of extension methods defined in the Extensions class.
            int[] ints = new[] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(ints.Csv);
            ints.GetEven().ToList().ForEach(i => Console.WriteLine(i));
            ints.GetOdd().ToList().ForEach(i => Console.WriteLine(i));

            // The following code will not compile because of the nullability of the Name property in the Person class.
            var p = new Person();
            p.Name ="null";

            //nameof operator can be used to get the name of a type, method, property, etc. as a string.
            var x = nameof(IEnumerable<>);
            Console.WriteLine(x);

            // The following code demonstrates the use of a delegate to convert an array of integers to a CSV string.
            //and new delegate in dotnet 10.0
            var e = new DelegateExample();            
            var ints2 = new[] { 7, 8, 9, 10 };
            string result;
            e.ConvertToCsv(ints2, out result);
            Console.WriteLine(result);

            var person = new PersonOperator(30, "John");
            Console.WriteLine(person);

            person += 5;
            Console.WriteLine(person);
        }
    }
    class PersonOperator 
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
        
}
