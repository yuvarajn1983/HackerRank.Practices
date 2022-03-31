using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRankPractices.EmployeeManagement
{
        public class Solution
        {

            public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
            {
                Dictionary<string, int> averageAge = new Dictionary<string, int>();
            var counts = employees.GroupBy(emp => emp.Company, age => age.Age)
.Select(group => new { group.Key, age = group.Average() })
.OrderBy(group => group.Key);
            foreach (var company in counts)
                averageAge.Add(company.Key, (int)company.age);
            return averageAge;
            }

            public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
            {
                Dictionary<string, int> employeeCount = new Dictionary<string, int>();
                var counts = employees.GroupBy(emp => emp.Company)
                .Select(group => new { group.Key, count = group.Count() })
                .OrderBy(group => group.Key);
                foreach (var company in counts)
                    employeeCount.Add(company.Key, company.count);
                 return employeeCount;
            }

            public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
            {
                Dictionary<string, Employee> oldestAge = new Dictionary<string, Employee>();
            var counts = employees.GroupBy(emp => emp.Company, age => age.Age)
.Select(group => new { group.Key, age = group.Max() })
.OrderBy(group => group.Key);
            foreach (var company in counts)
            {
                IEnumerable<Employee> result = from x in employees
                                             where x.Company == company.Key
                                             where x.Age == company.age
                                             select x;
                oldestAge.Add(company.Key, result.First());
            }
            return oldestAge;
            }

            public static void Run()
            {
                int countOfEmployees = int.Parse(Console.ReadLine());

                var employees = new List<Employee>();

                for (int i = 0; i < countOfEmployees; i++)
                {
                    string str = Console.ReadLine();
                    string[] strArr = str.Split(' ');
                    employees.Add(new Employee
                    {
                        FirstName = strArr[0],
                        LastName = strArr[1],
                        Company = strArr[2],
                        Age = int.Parse(strArr[3])
                    });
                }

                foreach (var emp in AverageAgeForEachCompany(employees))
                {
                    Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
                }

                foreach (var emp in CountOfEmployeesForEachCompany(employees))
                {
                    Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
                }

                foreach (var emp in OldestAgeForEachCompany(employees))
                {
                    Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
                }
            }
        }

        public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Company { get; set; }
        }
}
