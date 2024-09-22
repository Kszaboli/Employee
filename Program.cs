﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Employee
{

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Pay { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"C:\Users\szabolcs\Downloads\tulajdonsagok_100sor.txt";
            // Task 1 & 2: Reading the file and storing data
            string[] lines = File.ReadAllLines(FilePath);
            List<Employee> employees = new List<Employee>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                Employee emp = new Employee
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    Age = int.Parse(parts[2]),
                    Pay = int.Parse(parts[3])
                };
                employees.Add(emp);
            }

            //Task 3: Display all employees' names
            Console.WriteLine("All employee names:");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp.Name);
            }

            //Task 4: Display the ID and name of the employee(s) with the highest salary
            int maxPay = employees.Max(e => e.Pay);
            var topEarners = employees.Where(e => e.Pay == maxPay);

            Console.WriteLine("\nEmployee(s) with the highest salary:");
            foreach (var emp in topEarners)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Pay:{emp.Pay} Ft.");
            }

            Console.ReadKey();
        }
    }
}
