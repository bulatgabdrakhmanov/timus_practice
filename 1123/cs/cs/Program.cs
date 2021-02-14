using System;
using System.Numerics;
using System.Text;

namespace cs
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Program.GetSalaryPolindrome(Console.ReadLine()));
        }

        public static StringBuilder GetSalaryPolindrome(string s)
        {
            if (s.Length <= 1) return new StringBuilder(s);
            
            var result = new StringBuilder(s);
            
            var middleItemPos = (result.Length - 1) / 2;
            
            for (int i = middleItemPos + 1; i < result.Length; i++)
            {
                var item = result[i];
                var mirrorItem = result[result.Length - i - 1];
                
                if (item == mirrorItem) continue;
                if (item < mirrorItem) break;

                var remainder = 1;
                var j = middleItemPos;
                while (j >= 0 && remainder != 0)
                {
                    var currItem = result[j] - '0';
                    currItem += remainder;
                    remainder = currItem / 10;
                    result[j] = (currItem % 10).ToString()[0];
                    j--;
                }
                
                break;
            }

            for (int i = middleItemPos + 1; i < result.Length; i++)
            {
                result[i] = result[result.Length - i - 1];
            }

            return result;
        }
    }
}