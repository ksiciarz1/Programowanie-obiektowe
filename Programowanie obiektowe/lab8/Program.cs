using System;
using System.Collections.Generic;
using System.Threading;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool threadSuspend = false;
            ISet<int> primeNumbers1 = new HashSet<int>();
            ISet<int> primeNumbers2 = new HashSet<int>();
            ISet<int> primeNumbers3 = new HashSet<int>();
            ISet<int> primeNumbers4 = new HashSet<int>();
            ISet<int> primeNumbers5 = new HashSet<int>();


            // solution 1
            Thread PrimeNumbersThread1 = new Thread(() =>
            {
                int number = 1;
                while (!threadSuspend)
                {
                    lock (primeNumbers1)
                    {
                        number++;
                        int limit = (int)Math.Floor(Math.Sqrt(number));
                        for (int i = 2; i <= limit; ++i)
                        {
                            if (number % i == 0)
                            {
                                continue;
                            }
                        }
                        if (number >= 2)
                            primeNumbers1.Add(number);
                    }
                }
            });

            //solution 2
            Thread PrimeNumbersThread2 = new Thread(() =>
            {
                int number = 1;
                while (!threadSuspend)
                {
                    lock (primeNumbers2)
                    {
                        number++;
                        int count = 0;
                        for (int i = 1; i <= number; ++i)
                        {
                            if (number % i == 0)
                            {
                                count += 1;
                            }
                        }
                        if (count == 2)
                            primeNumbers2.Add(number);
                    }
                }
            });

            //solution 3
            Thread PrimeNumbersThread3 = new Thread(() =>
            {
                int number = 1;
                while (!threadSuspend)
                {
                    lock (primeNumbers3)
                    {
                        number++;
                        if (number < 2)
                        {
                            continue;
                        }
                        if (number == 2)
                        {
                            primeNumbers3.Add(number);
                            continue;
                        }
                        if (number % 2 == 0)
                        {
                            continue;
                        }
                        for (int i = 3; i < number; i += 2)
                        {
                            if (number % i == 0)
                            {
                                continue;
                            }
                        }
                        primeNumbers3.Add(number);
                    }
                }
            });

            //solution 4
            Thread PrimeNumbersThread4 = new Thread(() =>
            {
                int number = 1;
                while (!threadSuspend)
                {
                    lock (primeNumbers4)
                    {
                        number++;
                        if (number < 2)
                        {
                            continue;
                        }
                        if (number == 2)
                        {
                            primeNumbers4.Add(number);
                            continue;
                        }
                        for (int i = 2; i < number; ++i)
                        {
                            if (number % i == 0)
                            {
                                continue;
                            }
                        }
                        primeNumbers4.Add(number);
                    }
                }
            });

            // solution 5
            Thread PrimeNumbersThread5 = new Thread(() =>
            {
                int number = 1;
                while (!threadSuspend)
                {
                    lock (primeNumbers5)
                    {
                        number++;
                        if (number < 2)
                        {
                            continue;
                        }
                        if (number == 2 || number == 3)
                        {
                            primeNumbers5.Add(number);
                            continue;
                        }
                        if (number % 2 == 0)
                        {
                            continue;
                        }

                        int limit = (int)Math.Floor(Math.Sqrt(number));
                        for (int i = 5, d = 4; i <= limit; i += d)
                        {
                            if (number % i == 0)
                            {
                                continue;
                            }
                            d = 6 - d;
                        }
                        primeNumbers5.Add(number);
                    }
                    continue;
                }
            });

            PrimeNumbersThread1.Start();
            PrimeNumbersThread2.Start();
            PrimeNumbersThread3.Start();
            PrimeNumbersThread4.Start();
            PrimeNumbersThread5.Start();

            Thread.Sleep(10000);
            threadSuspend = true;

            PrimeNumbersThread1.Join();
            PrimeNumbersThread2.Join();
            PrimeNumbersThread3.Join();
            PrimeNumbersThread4.Join();
            PrimeNumbersThread5.Join();

            Console.WriteLine($"Znaleziono w solution 1 {primeNumbers1.Count} liczb pierwszych");
            Console.WriteLine($"Znaleziono w solution 2 {primeNumbers2.Count} liczb pierwszych");
            Console.WriteLine($"Znaleziono w solution 3 {primeNumbers3.Count} liczb pierwszych");
            Console.WriteLine($"Znaleziono w solution 4 {primeNumbers4.Count} liczb pierwszych");
            Console.WriteLine($"Znaleziono w solution 5 {primeNumbers5.Count} liczb pierwszych");
        }
    }
}
