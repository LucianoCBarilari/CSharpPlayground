using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPlayground.Others
{
    class Person
    {    //way  to avoid null in the setter of the property
        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                //using field in dotnet 10
                field = value ?? throw new ArgumentNullException(nameof(value), "Name cannot be null");
                //before dotnet 10, we would have to do something like this:
                //Name= value ?? throw new ArgumentNullException(nameof(value), "Name cannot be null");
            }
        }
    }
}
