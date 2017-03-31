using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MoreLinq;

namespace LevenshteinDistance
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Search: ");
            var search = Console.ReadLine();

            List<string> l;
            var d = new Dictionary<string, int>();

            using(var dbConnection = new SqliteConnection("DataSource=ygo.db"))
            {

                l = dbConnection.Query<string>("select name from Card").ToList();
                Console.WriteLine(l.Count);

            }

            foreach (var s in l)
            {

                if(!d.ContainsKey(s))
                    d.Add(s, Compute(search, s));

            }

            d = d.ToDictionary(kvalue => kvalue.Key.ToLower(), kvalue => kvalue.Value);
            var kv = d.MinBy(keyv => keyv.Value);

            Console.WriteLine(kv.Key + " " + kv.Value);
            Console.ReadKey();       

        }

        public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    }

    public class Card
    {

        public string name { get; set; }

    }

}
