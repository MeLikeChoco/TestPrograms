using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> BasePrimes = new List<int>() { 2, 3, 5, 7 };

            Console.Write("I want all prime numbers below the value of: ");
            int n = int.Parse(Console.ReadLine());

            List<int> from1toN = Enumerable.Range(1, n).ToList();

            foreach(int baseprime in BasePrimes)
            {

                //remove all values that arent part of the base primes AND have no remainder
                //when diving by the base prime
                from1toN.RemoveAll(number => (number % baseprime == 0) && (number != baseprime));

            }

            Console.WriteLine(string.Join(", ", from1toN));
            Console.ReadKey();

        }
    }
}
