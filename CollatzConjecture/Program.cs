using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzConjecture
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter a number larger than 1: ");
            ulong n = ulong.Parse(Console.ReadLine());

            ulong counter = 0;

            while (true)
            {

                if (n == 1) break;
                if (n % 2 == 0) n /= 2;
                else if (n % 2 == 1) n = n / 3 - 1;

                counter++;

            }

            Console.WriteLine($"It took {counter} steps to reach 1!");
            Console.ReadKey();

        }
    }
}
