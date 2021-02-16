using System;

namespace cs
{
    class Program
    {
        static string GetPalindromeSubstring(string text)
        {
            var result = text[0].ToString();

            for (var center = 0; center < text.Length; center++)
            {
                var left = center;
                var right = center;

                while (left > 0 && text[left - 1] == text[center]) left--;
                while (right < text.Length - 1 && text[right + 1] == text[center]) right++;

                while (left >= 1 && right < text.Length - 1 && text[left - 1] == text[right + 1])
                {
                    left--;
                    right++;
                }

                if (right - left + 1 > result.Length)
                {
                    result = text.Substring(left, right - left + 1);
                }
            }

            return result;
        }
        
        static void Main(string[] args)
        {
            var message = Console.ReadLine();
            var result = message.Length <= 1
                ? message
                : GetPalindromeSubstring(message);

            Console.WriteLine(result);
        }
    }
}