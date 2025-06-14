using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization;

public class Program
{
    static void Main(string[] args)
    {
        //Department object 
        var department = new Department
        {
            DepartmentName = "Accounting",
            Employees = new List<Employee>
            {
                new Employee { EmployeeName =  "John"},
                new Employee { EmployeeName = "Mark"}
            }
        };

        string filePath = "department.dat"; // file name

        //Serialize to binary file
        SerializeToBinaryFile(department, filePath);

        //Deserialize form the binary file
        var deserializeDepartment = DeserializeFromBinaryFile(filePath);

        //Print deserialized data
        Console.WriteLine($"Départment : {deserializeDepartment}");
        foreach (var employee in deserializeDepartment.Employees)
        {
            Console.WriteLine($"Employee: {employee.EmployeeName}");
        }
    }

    public static void SerializeToBinaryFile(Department department, string filePath)
    {
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            var format = new BinaryFormatter();
            format.Serialize(stream, department);
        }
    }

    public static Department DeserializeFromBinaryFile(string filePath)
    {
        using(var stream = new FileStream(filePath, FileMode.Open))
        {
            var format = new BinaryFormatter();
            return (Department)format.Deserialize(stream);
        }
    }
}