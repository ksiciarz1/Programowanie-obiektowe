using System;
using System.Collections.Generic;
using System.Linq;

namespace lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> userTable = new List<User>
            {
                new User("sdfgsdfgsd",  "ADMIN",     21, Array.Empty<int>()),
                new User("siciarz",     "ADMIN",     22, Array.Empty<int>()),
                new User("qweasa",      "ADMIN",     40, Array.Empty<int>()),
                new User("bvsdf",       "ADMIN",     34, Array.Empty<int>()),
                new User("ewrtdgs",     "ADMIN",     33, Array.Empty<int>()),
                new User("bndfghert",   "MODERATOR", 32, Array.Empty<int>()),
                new User("retyjhg",     "MODERATOR", 23, Array.Empty<int>()),
                new User("tjhgfhjas",   "MODERATOR", 54, Array.Empty<int>()),
                new User("retyujg",     "MODERATOR", 65, Array.Empty<int>()),
                new User("xcvfdsf",     "MODERATOR", 76, Array.Empty<int>()),
                new User("ertdfgsd",    "TEACHER",   42, Array.Empty<int>()),
                new User("dsfgcbxc",    "TEACHER",   35, Array.Empty<int>()),
                new User("sdghdfs",     "TEACHER",   54, Array.Empty<int>()),
                new User("eartgfsd",    "TEACHER",   34, Array.Empty<int>()),
                new User("cbcxdsfg",    "TEACHER",   43, Array.Empty<int>()),
                new User("aertdsfgsd",  "STUDENT",   18, new int[] {2,4,5,6}),
                new User("dbtresdfsg",  "STUDENT",   18, new int[] {2,2,5,6}),
                new User("ewyytrre",    "STUDENT",   18, new int[] {2,5,5,6}),
                new User("bfgewrt",     "STUDENT",   18, new int[] {2,6,5,6}),
                new User("sdarfgrrdsg", "STUDENT",   19, new int[] {2,2,2,6})
            };

            Console.WriteLine($"Ilośc rekordów w tablicy: {userTable.Count}");

            List<string> list = new List<string>();
            foreach (User user in userTable)
            {
                list.Add(user.Name);
            }

            List<User> sortedByName = userTable;
            sortedByName.Sort(delegate (User user1, User user2) { return user1.Name.CompareTo(user2.Name); });

            List<string> Roles = new List<string>() { "ADMIN, MODERATOR, TECHAER, STUDENT" };

            List<User> sortedByRole = userTable;
            sortedByRole.Sort(delegate (User user1, User user2) { return user1.Role.CompareTo(user2.Role); });

            int howManyRecordsWithMarks = 0;
            foreach (User user in userTable)
            {
                if (user.Marks != null)
                    if (user.Marks.Length > 0)
                        howManyRecordsWithMarks++;
            }
            List<int> Marks = new List<int>();
            foreach (User user in userTable)
            {
                if (user.Marks != null)
                    if (user.Marks.Length > 0)
                        foreach (int mark in user.Marks)
                            Marks.Add(mark);
            }

            int Sum = 0;
            foreach (int mark in Marks)
                Sum += mark;
            int Average = 0;
            foreach (int mark in Marks)
                Sum += mark;
            Average /= Marks.Count;
            int howManyMarks = 0;
            foreach (int mark in Marks)
                howManyMarks++;

            int lowestMark = Marks.Min();
            int highestMark = Marks.Max();


            int minimumMarkCount = 99;

            foreach (User user in userTable)
            {
                if (user.Marks != null)
                {
                    if (user.Marks.Length > 0)
                    {
                        if (user.Marks.Length < minimumMarkCount)
                            minimumMarkCount = user.Marks.Length;
                    }
                }
            }

            List<User> usersWithLowestMarkCount = new List<User>();

            foreach (User user in userTable)
            {
                if (user.Marks != null)
                    if (user.Marks.Length == minimumMarkCount)
                        usersWithLowestMarkCount.Add(user);
            }

            int maximumMarkCount = 0;

            foreach (User user in userTable)
            {
                if (user.Marks != null)
                {
                    if (user.Marks.Length > 0)
                    {
                        if (user.Marks.Length > maximumMarkCount)
                            maximumMarkCount = user.Marks.Length;
                    }
                }
            }

            List<User> usersWithMaximumMarkCount = new List<User>();

            foreach (User user in userTable)
            {
                if (user.Marks != null)
                    if (user.Marks.Length == maximumMarkCount)
                        usersWithMaximumMarkCount.Add(user);
            }

            List<User> sortedByBest = userTable;

            sortedByBest.Sort(delegate (User user1, User user2)
            {
                double average1 = user1.Marks.Average();
                double average2 = user2.Marks.Average();

                return average1.CompareTo(average2);
            });

            double allMarksAverage = Marks.Average();

            List<User> notDeleted = new List<User>();

            foreach (User user in userTable)
            {
                if (user.RemovedAt == null)
                    notDeleted.Add(user);
            }

            User latestUser = null;

            DateTime latestDate = DateTime.MinValue;

            foreach (User user in userTable)
            {
                if (user.CreatedAt != null)
                {
                    if (user.CreatedAt > latestDate)
                    {
                        latestDate = (DateTime)user.CreatedAt;
                        latestUser = user;
                    }
                }
            }

        }
    }
}
