﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool threadSuspend = false;
            ISet<int> primeNumbers = new HashSet<int>();


            // solution 1
            Thread PrimeNumbersThread1 = new Thread(() =>
            {
                int number = 1;
                while (!threadSuspend)
                {
                    number++;
                    Func<int, bool> func = new Func<int, bool>((number) =>
                    {
                        int limit = (int)Math.Floor(Math.Sqrt(number));
                        for (int i = 2; i <= limit; ++i)
                        {
                            if (number % i == 0)
                            {
                                return false;
                            }
                        }
                        if (number >= 2)
                        {
                            return true;
                        }
                        return false;
                    });
                    if (func(number))
                    {
                        lock (primeNumbers)
                            primeNumbers.Add(number);
                    }

                }
            });

            //solution 2
            Thread PrimeNumbersThread2 = new Thread(() =>
            {
                int number = 500;
                while (!threadSuspend)
                {
                    number++;
                    Func<int, bool> func = new Func<int, bool>((number) =>
                    {
                        int count = 0;
                        for (int i = 1; i <= number; ++i)
                        {
                            if (number % i == 0)
                            {
                                count += 1;
                            }
                        }
                        return count == 2;
                    });

                    if (func(number))
                    {
                        lock (primeNumbers)
                            primeNumbers.Add(number);
                    }
                }
            });

            //solution 3
            Thread PrimeNumbersThread3 = new Thread(() =>
            {
                int number = 1000;
                while (!threadSuspend)
                {
                    number++;
                    Func<int, bool> func = new Func<int, bool>((number) =>
                    {
                        if (number < 2)
                        {
                            return false;
                        }
                        if (number == 2)
                        {
                            return true;
                        }
                        if (number % 2 == 0)
                        {
                            return false;
                        }
                        for (int i = 3; i < number; i += 2)
                        {
                            if (number % i == 0)
                            {
                                return false;
                            }
                        }
                        return true;
                    });

                    if (func(number))
                    {
                        lock (primeNumbers)
                            primeNumbers.Add(number);
                    }
                }
            });

            //solution 4
            Thread PrimeNumbersThread4 = new Thread(() =>
            {
                int number = 1500;
                while (!threadSuspend)
                {
                    number++;
                    if (number < 2)
                    {
                        continue;
                    }
                    if (number == 2)
                    {
                        lock (primeNumbers)
                            primeNumbers.Add(number);
                        continue;
                    }
                    for (int i = 2; i < number; ++i)
                    {
                        if (number % i == 0)
                        {
                            break;
                        }
                    }
                    lock (primeNumbers)
                        primeNumbers.Add(number);

                }
            });

            // solution 5
            Thread PrimeNumbersThread5 = new Thread(() =>
            {
                int number = 2000;
                while (!threadSuspend)
                {
                    number++;
                    if (number < 2)
                    {
                        continue;
                    }
                    if (number == 2 || number == 3)
                    {
                        lock (primeNumbers)
                            primeNumbers.Add(number);
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
                            break;
                        }
                        d = 6 - d;
                    }
                    lock (primeNumbers)
                        primeNumbers.Add(number);
                    continue;
                }
            });


            PrimeNumbersThread1.Start();
            //PrimeNumbersThread2.Start();
            //PrimeNumbersThread3.Start();
            //PrimeNumbersThread4.Start();
            //PrimeNumbersThread5.Start();

            Thread.Sleep(10000);
            threadSuspend = true;

            PrimeNumbersThread1.Join();
            //PrimeNumbersThread2.Join();
            //PrimeNumbersThread3.Join();
            //PrimeNumbersThread4.Join();
            //PrimeNumbersThread5.Join();

            Console.WriteLine($"Znaleziono {primeNumbers.Count} liczb pierwszych"); // All threads combined
        }
    }
}