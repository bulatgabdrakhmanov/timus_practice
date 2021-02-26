using System;

namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            uint n = uint.Parse(Console.ReadLine());

            uint result = 0;

            for (int i = 0; i < 4; i++)
            {
                result += n % 256 * (uint)Math.Pow(256, 3 - i);
                n /= 256;
            }

            Console.WriteLine(result);
        }
    }
}
