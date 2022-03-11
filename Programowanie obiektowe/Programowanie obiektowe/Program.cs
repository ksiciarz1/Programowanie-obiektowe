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

            Console.WriteLine("// Sortowanie tablicy");

            Ulamek[] ulamekArray = new Ulamek[] { new Ulamek(5, 6), new Ulamek(1, 2), new Ulamek(4, 5), new Ulamek(6, 7) };

            for (int i = 0; i < ulamekArray.Length; i++)
            {
                Console.WriteLine(ulamekArray[i]);
            }

            Console.WriteLine("// Posortowane");
            ulamekArray = UlamekBubbleSort(ulamekArray);

            for (int i = 0; i < ulamekArray.Length; i++)
            {
                Console.WriteLine(ulamekArray[i]);
            }
        }

        public static Ulamek[] UlamekBubbleSort(Ulamek[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (j + 1 < array.Length)
                    {
                        if (array[j].CompareTo(array[j + 1]) > 0)
                        {
                            Ulamek temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            return array;
        }
    }
}
