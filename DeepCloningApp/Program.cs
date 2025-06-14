using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DeepCloningApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Create original Department object
            var originalDepartment = new Department
            {
                DepartmentName = "Engineering",
                Employees = new List<Employee>
                {
                    new Employee { EmployeeName = "Alice" },
                    new Employee { EmployeeName = "Bob" }
                }
            };

            Console.WriteLine("Original Department:");
            PrintDepartment(originalDepartment);

            // Step 2: Clone the Department object
            var clonedDepartment = DeepClone(originalDepartment);

            Console.WriteLine("\nCloned Department:");
            PrintDepartment(clonedDepartment);

            // Step 3: Modify cloned object to ensure it is independent from the original
            clonedDepartment.DepartmentName = "Sales";
            clonedDepartment.Employees[0].EmployeeName = "Charlie";

            Console.WriteLine("\nAfter Modifying Cloned Department:");
            Console.WriteLine("Original Department:");
            PrintDepartment(originalDepartment);

            Console.WriteLine("\nCloned Department:");
            PrintDepartment(clonedDepartment);
        }

        // Method to Deep Clone using Binary Serialization
        static T DeepClone<T>(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            using (var memoryStream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                // Serialize the object to the memory stream
                formatter.Serialize(memoryStream, obj);

                // Move stream position back to the beginning
                memoryStream.Seek(0, SeekOrigin.Begin);

                // Deserialize the object from the memory stream
                return (T)formatter.Deserialize(memoryStream);
            }
        }

        // Utility method to print Department details
        static void PrintDepartment(Department department)
        {
            Console.WriteLine($"Department Name: {department.DepartmentName}");
            Console.WriteLine("Employees:");
            foreach (var employee in department.Employees)
            {
                Console.WriteLine($"- {employee.EmployeeName}");
            }
        }
    }
}