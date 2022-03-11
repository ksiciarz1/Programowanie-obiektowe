using System;

namespace Programowanie_obiektowe
{
    class Program
    {
        static void Main(string[] args)
        {
            Ulamek ulamek1 = new Ulamek(1, 2);
            Ulamek ulamek2 = new Ulamek(3, 2);

            Console.WriteLine(ulamek1 * ulamek1);
            Console.WriteLine(ulamek1 + ulamek2);

            Console.WriteLine(ulamek1.RoundUp());
            Console.WriteLine(ulamek1.RoundDown());
        }
    }
}
