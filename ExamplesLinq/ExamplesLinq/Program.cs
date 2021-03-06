﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace ExamplesLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users1 = new List<User>
            {
                new User { Name = "Dave", Age = 25, Hobby = "Football", Language = "EN"},
                new User { Name = "Steve", Age = 25, Hobby = "Basketball", Language = "EN"},
                new User { Name = "Alice", Age = 19, Hobby = "Soccer", Language = "UA"},
                new User { Name = "Bob", Age = 18, Hobby = "Basketball", Language = "RU"},
                new User { Name = "Adam", Age = 23, Hobby = "Basketball", Language = "RU"},
                new User { Name = "Tom", Age = 25, Hobby = "Soccer", Language = "EN"}
            };
            List<User> users2 = new List<User>
            {
                new User { Name = "Daniel", Age = 22, Hobby = "Basketball", Language = "EN"},
                new User { Name = "Eva", Age = 26, Hobby = "Soccer", Language = "EN"},
                new User { Name = "Matt", Age = 35, Hobby = "Soccer", Language = "EN"}
            };
            users2.Add(users1[1]);
            users2.Add(users1[2]);
            users2.Add(users1[3]);
            List<Phone> phones = new List<Phone>
            {
                new Phone{Model = "IPhone", Price = 1000, Language = "EN"},
                new Phone{Model = "Samsung", Price = 1200, Language = "EN"},
                new Phone{Model = "Huawei", Price = 900, Language = "UA"},
                new Phone{Model = "Nokia", Price = 500, Language = "RU"}
            };

            #region
            //SimpleWhere(users1);
            //ComplicatedWhere(users1);
            //SimpleSelect(users1);
            //ComplicatedSelect(users1);
            //OrderBy(users1);
            //ThenBy(users1);
            //OrderByDescending(users1);
            //ThenByDescending(users1);
            //Except(users1, users2);
            //Intersect(users1, users2);
            //Union(users1, users2);
            //Concat(users1, users2);
            //Aggregate(users1);
            //Count(users1);
            //Sum(users1);
            //MinMaxAvagare(users1);
            //Skip(users1);
            //SkipWhile(users1);
            //Take(users1);
            //TakeWhile(users1);
            //GroupBy(users1);
            //GroupBy(users1);
            //Join(users1, phones);
            //Zip(users1, phones);
            //All(users1);
            //Any(users1);
            #endregion

            //string[] strings = { "str1", "str2", "str3", "str4", "str5", "str6" };
            //var result = strings.Aggregate("MainSTR",(x, y) => x + y);
            //Console.WriteLine(result);

            //Console.WriteLine("LINQ method where:");
            //Console.WriteLine("Filter users by age > 20 and name contain 'a'");

        }

        private static void Any(List<User> users)
        {
            Console.WriteLine("LINQ method All:");
            Console.WriteLine("Check if any user is 20+");

            bool any = users.Any(u => u.Age >= 20);
            Console.WriteLine(any);

        }

        private static void All(List<User> users)
        {
            Console.WriteLine("LINQ method All:");
            Console.WriteLine("Check if all users 20+");

            bool all = users.All(u => u.Age >= 20);

            Console.WriteLine(all);

        }

        private static void Zip(List<User> users, List<Phone> phones)
        {
            Console.WriteLine("LINQ method Zip:");

            var zipedList = users.Zip(phones,
                (user, phone) => new
                {
                    Name = user.Name,
                    Model = phone.Model
                });

            Console.WriteLine("Users:");
            foreach (User user in users)
            {
                user.Print();
            }

            Console.WriteLine("Phones:");
            foreach (Phone phone in phones)
            {
                phone.Print();
            }

            foreach (var zipedItem in zipedList)
            {
                Console.WriteLine($"{zipedItem.Name} - {zipedItem.Model}");
            }


        }

        private static void Join(List<User> users, List<Phone> phones)
        {
            Console.WriteLine("LINQ method Join:");

            Console.WriteLine("Users:");
            foreach (User user in users)
            {
                user.Print();
            }

            Console.WriteLine("Phones:");
            foreach (Phone phone in phones)
            {
                phone.Print();
            }

            Console.WriteLine("Join:");
            var joined = users.Join(phones,
                u => u.Language,
                p => p.Language,
                (u, p) => new { u.Name, p.Model });

            foreach (var item in joined)
            {
                Console.WriteLine($"{item.Model}, {item.Name}");
            }

        }

        private static void GroupBy(List<User> users)
        {
            Console.WriteLine("LINQ method GroupBy:");
            Console.WriteLine("Group users by their hobby");

            var groupedUsers = users.GroupBy(u => u.Hobby);

            foreach (var usersGroup in groupedUsers)
            {
                Console.WriteLine($"{usersGroup.Key} : {usersGroup.Count()}");
                foreach (User user in usersGroup)
                {
                    user.Print();
                }
            }

        }

        private static void TakeWhile(List<User> users)
        {
            Console.WriteLine("LINQ method TakeWhile:");
            Console.WriteLine("Takes users while age > 20");

            var oldUsers = users.TakeWhile(x => x.Age > 20);

            Console.WriteLine("Users:");
            foreach (User user in users)
            {
                user.Print();
            }

            Console.WriteLine("Old users:");
            foreach (User user in oldUsers)
            {
                user.Print();
            }

        }

        private static void SkipWhile(List<User> users)
        {
            Console.WriteLine("LINQ method SkipWhile:");
            Console.WriteLine("Skips users while it's age more 20");

            var SkipedList = users.SkipWhile(x => x.Age > 20);

            Console.WriteLine("Users:");
            foreach (User user in users)
            {
                user.Print();
            }

            Console.WriteLine("Skiped list:");
            foreach (User user in SkipedList)
            {
                user.Print();
            }

        }

        private static void Take(List<User> users)
        {
            Console.WriteLine("LINQ method Take:");
            Console.WriteLine("Prints first 3 users");

            var firstUsers = users.Take(3);

            Console.WriteLine("Users:");
            foreach (User user in users)
            {
                user.Print();
            }

            Console.WriteLine("First 3 users:");
            foreach (User user in firstUsers)
            {
                user.Print();
            }

        }

        private static void Skip(List<User> users)
        {
            Console.WriteLine("LINQ method Skip:");
            Console.WriteLine("Prints users without first 3 users");

            var skipedUsers = users.Skip(3);

            Console.WriteLine("User list:");
            foreach (User user in users)
            {
                user.Print();
            }

            Console.WriteLine("Skiped list:");
            foreach (User user in skipedUsers)
            {
                user.Print();
            }

        }

        private static void MinMaxAvagare(List<User> users)
        {
            Console.WriteLine("LINQ methods min, max and avarage:");
            Console.WriteLine("Prints min, max and avarage age value");

            int min = users.Min(u => u.Age);
            int max = users.Max(u => u.Age);
            double avarage = users.Average(u => u.Age);

            Console.WriteLine($"Min = {min}, max = {max}, avarage = {avarage}");

        }

        private static void Sum(List<User> users)
        {
            Console.WriteLine("LINQ method Sum:");
            Console.WriteLine("Get sum of users ages");
            int ageSum = users.Sum(u => u.Age);
            Console.WriteLine($"Sum users age {ageSum}");
        }

        private static void Count(List<User> users)
        {
            Console.WriteLine("LINQ method Count:");
            Console.WriteLine("Counts number of users 20+");

            Console.WriteLine($"All users number {users.Count()}");

            int count = users.Count(u => u.Age >= 20);
            Console.WriteLine($"There is {count} users 20+");
        }

        private static void Aggregate(List<User> users)
        {
            Console.WriteLine("LINQ method aggregate:");
            Console.WriteLine("Prints sum of users ages");

            int sumAge = users.Select(u => u.Age).Aggregate((x, y) => x + y);
            Console.WriteLine($"Users age = {sumAge}");
        }

        private static void Concat(List<User> users1, List<User> users2)
        {
            Console.WriteLine("LINQ method Concat:");
            Console.WriteLine("Prints list that contains all members from two lists");

            var concatedList = users1.Concat(users2);

            foreach (User user in concatedList)
            {
                user.Print();
            }

        }

        private static void Union(List<User> users1, List<User> users2)
        {
            Console.WriteLine("First list");
            foreach (User user in users1.OrderBy(u => u.Name))
            {
                user.Print();
            }

            Console.WriteLine("Second list");
            foreach (User user in users2.OrderBy(u => u.Name))
            {
                user.Print();
            }

            var unitedList = users1.Union(users2);

            Console.WriteLine("LINQ method Union:");
            Console.WriteLine("Prints every element from two lists without repeated");
            foreach (User user in unitedList.OrderBy(u => u.Name))
            {
                user.Print();
            }


        }

        static void SimpleWhere(List<User> users)
        {
            Console.WriteLine("LINQ method where:");
            Console.WriteLine("Filter users by age > 20");
            var filteredUsers = users.Where(u => u.Age > 20);
            foreach (User user in filteredUsers)
            {
                user.Print();
            }
        }

        static void ComplicatedWhere(List<User> users)
        {
            Console.WriteLine("LINQ method where:");
            Console.WriteLine("Filter users by age > 20 and name contain 'a'");

            var filteredUsers = users.Where(x => x.Age > 20).Where(x => x.Name.Contains('a'));

            foreach (User user in filteredUsers)
            {
                user.Print();
            }

        }

        static void SimpleSelect(List<User> users)
        {
            Console.WriteLine("LINQ method Select:");
            Console.WriteLine("Select users names and languages");

            var selectedValues = users.Select(x => new { x.Name, x.Language });

            foreach (var userInfo in selectedValues)
            {
                Console.WriteLine($"{userInfo.Name}, {userInfo.Language}");
            }
        }

        static void ComplicatedSelect(List<User> users)
        {
            Console.WriteLine("LINQ method select:");
            Console.WriteLine("if user older 20 show hobby else show age");

            var filteredList = users.Select(x =>
            {
                if (x.Age > 20)
                {
                    return new { x.Name, value = x.Hobby };
                }
                else
                {
                    return new { x.Name, value = x.Age.ToString() };
                }
            });
            foreach (var item in filteredList)
            {
                Console.WriteLine($"{item.Name}, {item.value}");
            }

        }

        static void SelectFromTwoLists(List<User> users, List<Phone> phones)
        {
            Console.WriteLine("LINQ method select:");
            Console.WriteLine("Get pairs username + phonemodel");

            //var resultList = users.SelectMany()

            //foreach (var item in resultList)
            //{
            //    Console.WriteLine($"{item.Name}");
            //}
            //NOT FINISHED

        }

        static void OrderBy(List<User> users)
        {
            Console.WriteLine("LINQ method orderby:");
            Console.WriteLine("Sort list by name");

            var sortedList = users.OrderBy(u => u.Name);
            foreach (User user in sortedList)
            {
                user.Print();
            }

        }

        static void ThenBy(List<User> users)
        {
            Console.WriteLine("LINQ method ThenBy:");
            Console.WriteLine("Sort list by username and than by age");

            var sortedList = users.OrderBy(u => u.Name).ThenBy(u => u.Age);

            foreach (var user in sortedList)
            {
                user.Print();
            }

        }

        static void OrderByDescending(List<User> users)
        {
            Console.WriteLine("LINQ method OrderByDescending:");
            Console.WriteLine("Sort descending by username");

            var sortedList = users.OrderByDescending(u => u.Name);

            foreach (User user in sortedList)
            {
                user.Print();
            }
        }

        static void ThenByDescending(List<User> users)
        {
            Console.WriteLine("LINQ method ThenByDescending:");
            Console.WriteLine("Sort descending by username and than by age");

            var sortedList = users.OrderByDescending(u => u.Name).ThenByDescending(u => u.Age);

            foreach (User user in sortedList)
            {
                user.Print();
            }

        }

        static void Except(List<User> users1, List<User> users2)
        {
            var exceptedList = users1.Except(users2);

            Console.WriteLine("First list:");
            foreach (User user in users1.OrderBy(u => u.Name))
            {
                user.Print();
            }

            Console.WriteLine("Second list:");
            foreach (User user in users2.OrderBy(u => u.Name))
            {
                user.Print();
            }

            Console.WriteLine("LINQ method Except:");
            Console.WriteLine("Print difference between two lists");

            foreach (User user in exceptedList.OrderBy(u => u.Name))
            {
                user.Print();
            }

        }

        static void Intersect(List<User> users1, List<User> users2)
        {
            Console.WriteLine("First list");
            foreach (User user in users1.OrderBy(u => u.Name))
            {
                user.Print();
            }

            Console.WriteLine("Second list");
            foreach (User user in users2.OrderBy(u => u.Name))
            {
                user.Print();
            }

            var intersectedList = users1.Intersect(users2);

            Console.WriteLine("LINQ method Intersct:");
            Console.WriteLine("Prints common between two lists");
            foreach (User user in intersectedList.OrderBy(u => u.Name))
            {
                user.Print();
            }

        }

    }
}

