using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool threadSuspend = false;
            CancellationTokenSource taskSuspend = new CancellationTokenSource();

            ISet<int> primeNumbers = new HashSet<int>();

            Thread[] threads = new Thread[5];
            Task[] tasks = new Task[5];


            // Solution 1
            threads[0] = new Thread(() =>
            {
                int number = 1;
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
                while (!threadSuspend)
                {
                    number++;
                    if (func(number))
                    {
                        lock (primeNumbers)
                            primeNumbers.Add(number);
                    }

                }
            });
            tasks[0] = new Task(() =>
            {
                int number = 1;
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
                while (!threadSuspend)
                {
                    number++;
                    if (func(number))
                    {
                        lock (primeNumbers)
                            primeNumbers.Add(number);
                    }

                }
            }, taskSuspend.Token);

            // Solution 2
            threads[1] = new Thread(() =>
             {
                 int number = 500;
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
                 while (!threadSuspend)
                 {
                     number++;

                     if (func(number))
                     {
                         lock (primeNumbers)
                             primeNumbers.Add(number);
                     }
                 }
             });
            tasks[1] = new Task(() =>
            {
                int number = 500;
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
                while (!threadSuspend)
                {
                    number++;

                    if (func(number))
                    {
                        lock (primeNumbers)
                            primeNumbers.Add(number);
                    }
                }
            }, taskSuspend.Token);


            // Solution 3
            threads[2] = new Thread(() =>
            {
                int number = 1000;
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
                while (!threadSuspend)
                {
                    number++;

                    if (func(number))
                    {
                        lock (primeNumbers)
                            primeNumbers.Add(number);
                    }
                }
            });
            tasks[2] = new Task(() =>
            {
                int number = 1000;
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
                while (!threadSuspend)
                {
                    number++;

                    if (func(number))
                    {
                        lock (primeNumbers)
                            primeNumbers.Add(number);
                    }
                }
            }, taskSuspend.Token);


            // Solution 4
            threads[3] = new Thread(() =>
            {
                int number = 1500;
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
                    for (int i = 2; i < number; ++i)
                    {
                        if (number % i == 0)
                        {
                            return false;
                        }
                    }
                    return true;
                });
                while (!threadSuspend)
                {
                    number++;
                    if (func(number))
                    {
                        lock (primeNumbers)
                            primeNumbers.Add(number);
                    }

                }
            });
            tasks[3] = new Task(() =>
            {
                int number = 1500;
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
                    for (int i = 2; i < number; ++i)
                    {
                        if (number % i == 0)
                        {
                            return false;
                        }
                    }
                    return true;
                });
                while (!threadSuspend)
                {
                    number++;
                    if (func(number))
                    {
                        lock (primeNumbers)
                            primeNumbers.Add(number);
                    }

                }
            }, taskSuspend.Token);


            // Solution 5
            threads[4] = new Thread(() =>
            {
                int number = 2000;
                Func<int, bool> func = new Func<int, bool>((number) =>
                {
                    if (number < 2)
                    {
                        return false;
                    }
                    if (number == 2 || number == 3)
                    {
                        return true;
                    }
                    if (number % 2 == 0)
                    {
                        return false;
                    }

                    int limit = (int)Math.Floor(Math.Sqrt(number));
                    for (int i = 5, d = 4; i <= limit; i += d)
                    {
                        if (number % i == 0)
                        {
                            return false;
                        }
                        d = 6 - d;
                    }
                    return true;
                });

                while (!threadSuspend)
                {
                    number++;
                    if (func(number))
                    {
                        lock (primeNumbers)
                            primeNumbers.Add(number);
                    }
                }
            });
            tasks[4] = new Task(() =>
            {
                int number = 2000;
                Func<int, bool> func = new Func<int, bool>((number) =>
                {
                    if (number < 2)
                    {
                        return false;
                    }
                    if (number == 2 || number == 3)
                    {
                        return true;
                    }
                    if (number % 2 == 0)
                    {
                        return false;
                    }

                    int limit = (int)Math.Floor(Math.Sqrt(number));
                    for (int i = 5, d = 4; i <= limit; i += d)
                    {
                        if (number % i == 0)
                        {
                            return false;
                        }
                        d = 6 - d;
                    }
                    return true;
                });

                while (!threadSuspend)
                {
                    number++;
                    if (func(number))
                    {
                        lock (primeNumbers)
                            primeNumbers.Add(number);
                    }
                }
            }, taskSuspend.Token);


            foreach (Thread thread in threads)
            {
                thread.Start();
            }

            foreach (Task task in tasks)
            {
                task.Start();
            }

            Thread.Sleep(10000);
            threadSuspend = true;
            taskSuspend.Cancel();

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            Task.WaitAll(tasks);

            Console.WriteLine($"Znaleziono {primeNumbers.Count} liczb pierwszych"); // All threads and tasks combined
        }
    }
}
