using System;

namespace cs
{
    class Program
    {
        static string CalculateCoors(string buttons)
        {
            double x = 0;
            double y = 0;
            double diagonalDistance = 1 / Math.Sqrt(2);

            foreach (var button in buttons)
            {
                if (button == '0') break;

                switch (button)
                {
                    case '1':
                        y -= diagonalDistance;
                        x -= diagonalDistance;
                        break;
                    
                    case '2':
                        y--;
                        break;
                    
                    case '3':
                        y -= diagonalDistance;
                        x += diagonalDistance;
                        break;
                    
                    case '4':
                        x--;
                        break;

                    case '6':
                        x++;
                        break;
                    
                    case '7':
                        y += diagonalDistance;
                        x -= diagonalDistance;
                        break;
                    
                    case '8':
                        y++;
                        break;
                    
                    case '9':
                        y += diagonalDistance;
                        x += diagonalDistance;
                        break;
                }
            }
            
            return x.ToString("n10").Replace(",", ".") + 
                   " " + 
                   y.ToString("n10").Replace(",", ".");
        }
        
        static void Main(string[] args)
        {
            string buttons = Console.ReadLine();
            Console.WriteLine(CalculateCoors(buttons));
        }
    }
}