using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Linq.Entities
    {
    class Program
        {
        static void Print <T>(string message,IEnumerable<T> collection)
            {
            Console.WriteLine(message);
            foreach (T obj in collection)
                {
                Console.WriteLine(obj);
                }
            Console.WriteLine();
            }

        static void Main(string[] args)
            {
            try
                {
                Console.Write("Enter full file path: ");
                string path = Console.ReadLine();

                List<Employee> list = new List<Employee>();

                using (StreamReader sr = File.OpenText(path))
                    {
                    while (!sr.EndOfStream)
                        {
                        string[] fiels = sr.ReadLine().Split(',');
                        string name = fiels[0];
                        string email = fiels[1];
                        double _salary = double.Parse((fiels[2]), CultureInfo.InvariantCulture);

                        list.Add(new Employee(name, email, _salary));
                        }
                    }

                Console.Write("Enter Salary: ");
                double salary = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                var s1 = list.Where(e => e.Salary > salary).OrderBy(e => e.Email).Select(e => e.Email);

                Console.WriteLine("Email of people whose salary is more than " + salary.ToString("f2", CultureInfo.InvariantCulture) + ":");
                Print("", s1);

                var s2 = list.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);

                Console.Write("Sum of salary of people whose name starts with 'M': ");
                Console.WriteLine(s2.ToString(), CultureInfo.InvariantCulture);
                }
            catch(Exception E)
                {
                Console.WriteLine("An Error Occurred");
                Console.WriteLine(E.Message);
                }

            }
        }
    }
