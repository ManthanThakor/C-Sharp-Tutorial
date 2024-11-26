using System;

namespace SingleReposibilityPrinciple
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }
    public class TaxCalculator
    {
        public double CalculateTax(Employee employee)
        {
            return employee.Salary * 0.1;
        }
    }
    public class EmployeeRepository
    { 
        public void Save(Employee employee)
        {
            Console.WriteLine($"Employee {employee.Name} saved to database.");
        }
    }
    class Program
    {
         static void Main(string[] args)
        {
            Console.WriteLine("Solid Principle : 1. Single-Reponibility-Principle");
            Employee employee = new Employee
            {
                Id = 1,
                Name = "Xyz",
                Salary = 50000
            };
            Console.WriteLine("\n Employee Deaitls \n");
            Console.WriteLine($"Employee Id: {employee.Id} \nEmployee Name: {employee.Salary} \nEmployee Salary {employee.Salary} \n");


            TaxCalculator taxCalculator = new TaxCalculator();
            double tax = taxCalculator.CalculateTax(employee);
            Console.WriteLine($"Tax for {employee.Name}: {tax} \n");

            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.Save(employee);

            Console.ReadLine();
        }
    }
}