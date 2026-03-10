using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Slices.Exercises
{
    public class ReturnBinary
    {
        int RetunBinary(int Num)
        {
            List<int> Binary = new();
            int N = Num;
            int R = 0;
            int counter = 0;
            int LastCounter = 0;

            do
            {
                N = N / 2;
                R = Num - 2 * N;
                Num = N;
                Binary.Add(R);
            } while (N > 0);


            for (int i = 0; i < Binary.Count(); i++)
            {
                if (Binary[i] == 1)
                {
                    counter++;
                    if (counter > LastCounter)
                        LastCounter = counter;
                }
                else if (Binary[i] == 0)
                {
                    counter = 0;
                }

            }
            return LastCounter;

        }
    }
}

