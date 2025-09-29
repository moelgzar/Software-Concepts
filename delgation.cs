using System;
using System.Collections.Generic;

namespace Deleegation
{
    internal class Program
    {


        public class employee
        {
            public string Name { get; set; }
            public int BasicSalary { get; set; }
            public int Deduction { get; set; }
            public int Bonis { get; set; }
        }

        public delegate bool ShouldCalculate(employee employee);


       

        // Make it static so Main can call it directly
        public static void CalculateSalaries(List<employee> employees, ShouldCalculate predicate)
        {
            foreach (employee emp in employees)
            {
                if (predicate(emp))
                {
                    Console.WriteLine($"{emp.Name} ---> Salary = {emp.BasicSalary}");
                }
            }
        }

        //public static bool IsFound(employee emp)
        //{
        //    Console.WriteLine("now i'am running is found function \n");
        //    return emp.Name == "aEmployee 3";
        //}

        static void Main(string[] args)
        {
            List<employee> employees = new List<employee>();
            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                employees.Add(new employee
                {
                    Name = $"Employee {i}",
                    BasicSalary = rnd.Next(1000, 5001),
                    Deduction = rnd.Next(0, 5001),
                    Bonis = rnd.Next(0, 1001)
                });
            }

            // Call the method
            CalculateSalaries(employees, (e) => e.BasicSalary <=2000);
            Console.WriteLine("0000000000000000000000000000000000000000000");
            CalculateSalaries(employees, (e) => e.Bonis <=200);
            Console.WriteLine("0000000000000000000000000000000000000000000");

            CalculateSalaries(employees, (e) => e.Bonis + e.BasicSalary + e.Deduction <=3000);
            //CalculateSalaries(employees, IsFound);
            // give me reusable code and flexbileity to do a lot of funcution easily 
            Console.ReadLine();
        }

      
    }
}
