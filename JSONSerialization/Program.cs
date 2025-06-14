using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSONSerialization;

public class Program
{
    static void Main(string[] args)
    {
        var department = new Department
        {
            DepartmentName = "Sales",
            Employees = new List<Employee>
            {
                new Employee {EmployeeName = "Todd"},
                new Employee {EmployeeName = "Sarah"}
            }
        };

        string filePath = "department.json";

        // Serialize to a JSON file
        SerializeToJsonFile(department, filePath);

        //Serialize to a JSON file
        var deserializedDepartment = DeserializeFromJSONFile(filePath);
        // Print deserialized data

        Console.WriteLine($"Department: {deserializedDepartment.DepartmentName}");
        foreach (var employee in deserializedDepartment.Employees)
        {
            Console.WriteLine($"Employee: {employee.EmployeeName}");
        }

    }

    public static void SerializeToJsonFile(Department department, string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(department, options);
        File.WriteAllText(filePath, json);
    }

    public static Department DeserializeFromJSONFile(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Department>(json);
    }
}