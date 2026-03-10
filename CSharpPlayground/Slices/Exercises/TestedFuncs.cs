using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Slices.Exercises
{
    public class TestedFuncs
    {
        //MathFactorial

        // 5x4x3x2x1 = 120
        //5x4 =20
        //20x3=60
        //60x2=120
        //120x1=120



        int Factorial(int N)
        {
            int R = N;
            for (int i = 1; i < N; i++)
            {
                R *= N - i;
            }
            return R;
        }

        int RecursiveFactorial(int N)
        {
            if (N <= 1)
                return 1;
            return N * RecursiveFactorial(N - 1);
        }
    }
}

