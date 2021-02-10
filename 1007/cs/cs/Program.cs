using System;
using System.Collections.Generic;
using System.Text;

namespace cs
{
    public class Program
    {
        private static bool ModIs0(int a, int b)
        {
            return a % b == 0;
        }
        
        private static string ReplacedCode(string code)
        {
            var n = code.Length;
            var result = new StringBuilder(code);
            
            var sum = 0;
            var unitPositions = new List<int>();

            for (var i = 0; i < code.Length; i++)
            {
                if (code[i] == '0') continue;
                unitPositions.Add(i + 1);
                sum += i + 1;
            }

            if (ModIs0(sum, n + 1)) return code;

            var fakeUnitPosition = unitPositions.Find(x => ModIs0(sum - x, n + 1));
            result[fakeUnitPosition - 1] = '0';
            return result.ToString();
        }
        
        private static string SupplementedCode(string code)
        {
            var n = code.Length + 1;
            var result = new StringBuilder(code);
            
            var sum = 0;
            var unitPositions = new List<int>();

            for (var i = 0; i < code.Length; i++)
            {
                if (code[i] == '0') continue;
                unitPositions.Add(i + 1);
                sum += i + 1;
            }
            
            if (ModIs0(sum, n + 1)) return code + "0";

            var unitsLeft = unitPositions.Count;
            var insertItemPos = 0;
            var insertItem = '0';
            for (var i = 0; i < n; i++)
            {
                if (ModIs0(sum + unitsLeft, n + 1) || ModIs0(sum + unitsLeft + i + 1, n + 1))
                {
                    insertItem = (sum + unitsLeft) % (n + 1) == 0 ? '0' : '1';
                    insertItemPos = i;
                    break;
                }

                if (code[i] == '1') unitsLeft--;
            }
                
            result.Insert(insertItemPos, insertItem);
            return result.ToString();
        }
        
        private static string StrippedCode(string code)
        {
            var n = code.Length - 1;
            var result = new StringBuilder(code);
            
            var sum = 0;
            var unitPositions = new List<int>();

            for (var i = 0; i < code.Length; i++)
            {
                if (code[i] == '0') continue;
                unitPositions.Add(i + 1);
                sum += i + 1;
            }

            var deleteItemPos = 0;
            var unitsLeft = unitPositions.Count;
            for (var i = 0; i < code.Length; i++)
            {
                var c = code[i];
                var is1 = c == '1';
                unitsLeft = is1 ? unitsLeft - 1 : unitsLeft;
                var currUnitPos = is1 ? i + 1 : 0;

                if (!ModIs0(sum - unitsLeft - currUnitPos, n + 1)) continue;
                
                deleteItemPos = i;
                break;
            }

            result.Remove(deleteItemPos, 1);
            return result.ToString();
        }

        private static int ReadN()
        {
            return int.Parse(Console.ReadLine());
        }
        
        private static List<string> ReadCodes()
        {
            var codes = new List<string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == null) break;
                if (input == "") continue;
                codes.Add(input);
            }

            return codes;
        }

        static void Main(string[] args)
        {
            var n = ReadN();
            var codes = ReadCodes();

            foreach (var code in codes)
            {
                var len = code.Length;
                string result;

                if (len == n) result = ReplacedCode(code);
                else if (len < n) result = SupplementedCode(code);
                else result = StrippedCode(code);

                Console.WriteLine(result);
            }
        }
    }
}
