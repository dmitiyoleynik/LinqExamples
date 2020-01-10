using System;
using System.Collections.Generic;
using System.Linq;


namespace ExamplesLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>
            {
                new User { Name = "Dave", Age = 25, Hobby = "Football", Language = "EN"},
                new User { Name = "Steve", Age = 25, Hobby = "Basketball", Language = "EN"},
                new User { Name = "Alice", Age = 19, Hobby = "Soccer", Language = "UA"},
                new User { Name = "Bob", Age = 18, Hobby = "Basketball", Language = "RU"},
                new User { Name = "Tom", Age = 25, Hobby = "Soccer", Language = "EN"}
            };
            List<Phone> phones = new List<Phone>
            {
                new Phone{Model = "IPhone", Price = 1000},
                new Phone{Model = "Samsung", Price = 1200},
                new Phone{Model = "Huawei", Price = 900},
                new Phone{Model = "Nokia", Price = 500}
            };

            SimpleWhere(users);
            ComplicatedWhere(users);
            SimpleSelect(users);
            ComplicatedSelect(users);

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

            var filteredList = users.Select(x => {
                if (x.Age>20)
                {
                    return new { x.Name, value = x.Hobby };
                } else
                {
                    return new { x.Name, value = x.Age.ToString() };
                }
            });
            foreach (var item in filteredList)
            {
                Console.WriteLine($"{item.Name}, {item.value}");
            }

        }

        static void SelectFromTwoLists(List<User> users,List<Phone> phones)
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

    }
}

            //Console.WriteLine("LINQ method where:");
            //Console.WriteLine("Filter users by age > 20 and name contain 'a'");
