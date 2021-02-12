using System;
using System.Numerics;

namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(' ');
            var n = int.Parse(tokens[0]);
            var m = int.Parse(tokens[1]);

            var max = 9 * n;
            if (m % 2 == 1 || m > max * 2)
            {
                Console.WriteLine(0);
                return;
            }

            m = m > max ? max + max - m : m;
            
            var spread = new BigInteger[51, 1001];

            for (var i = 0; i <= 18; i += 2) spread[1, i] = 1;
            for (var i = 1; i <= n; i++) spread[i, 0] = 1;

            for (var i = 2; i <= n; i++)
            {
                for (var j = 2; j <= m; j += 2)
                {
                    spread[i, j] = spread[i, j - 2] + spread[i - 1, j];
                    if (j >= 20) spread[i, j] -= spread[i - 1, j - 20];
                }
            }

            Console.WriteLine(spread[n, m] * spread[n, m]);
        }
    }
}