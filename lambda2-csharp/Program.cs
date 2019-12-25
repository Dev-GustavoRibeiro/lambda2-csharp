using lambda2_csharp.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace lambda2_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    List<Employee> list = new List<Employee>();
                    while (!sr.EndOfStream)
                    {
                        string[] vet = sr.ReadLine().Split(',');
                        string name = vet[0];
                        string email = vet[1];
                        double salary = double.Parse(vet[2], CultureInfo.InvariantCulture);
                        list.Add(new Employee(name, email, salary));
                    }

                    Console.Write("Enter salary: ");
                    double filter = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Console.WriteLine("Email of people whose salary is more than 2000.00:");
                    var filterSalary = list.Where(e => e.Salary > 2000.00).OrderBy(e => e.Email).Select(e => e.Email);
                    foreach (string email in filterSalary)
                    {
                        Console.WriteLine(email);
                    }

                    var sumSalary = list.Where(e => e.Name[0] == 'M').Select(e => e.Salary).Sum();
                    Console.Write("Sum of salary of people whose name starts with 'M': " + sumSalary.ToString("F2", CultureInfo.InvariantCulture));
                    Console.WriteLine();
                }
            }
            catch (IOException E)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(E.Message);
            }
        }
    }
}