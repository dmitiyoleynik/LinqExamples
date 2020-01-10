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

            SimpleWhere(users);
            ComplicatedWhere(users);

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

    }
}
