using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XMLSerialization;

public class Program
{
    static void Main(string[] args)
    {
        //Create department
        var department = new Department
        {
            DepartmentName = "Marketing",
            Employees = new List<Employee>
            {
                new Employee{ EmployeeName = "Sam"},
                new Employee{ EmployeeName = "Ron"}
            }
        };
        string filePath = "department.xml";

        // Serialize to an XML file
        SerializeToXmlFile(department, filePath);

        // Deserialize from the XML file
        var deserializedDepartment = DeserializeFromXmlFile(filePath);

        // Print deserialized data
        Console.WriteLine($"Department: {deserializedDepartment.DepartmentName}");
        foreach (var employee in deserializedDepartment.Employees)
        {
            Console.WriteLine($"Employee: {employee.EmployeeName}");
        }
    }

    public static void SerializeToXmlFile(Department department, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            var serializer = new XmlSerializer(typeof(Department));
            serializer.Serialize(writer, department);
        }
    }

    public static Department DeserializeFromXmlFile(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            var serializer = new XmlSerializer(typeof(Department));
            return (Department)serializer.Deserialize(reader);
        }
    }
}
