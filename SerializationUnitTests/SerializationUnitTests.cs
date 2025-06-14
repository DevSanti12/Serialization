namespace SerializationUnitTests
{
    public class SerializationUnitTests
    {
        [Fact]
        public void TestBinarySerialization()
        {
            // Arrange
            var originalDepartment = new BinarySerialization.Department
            {
                DepartmentName = "Engineering",
                Employees = new List<BinarySerialization.Employee>
            {
                new BinarySerialization.Employee { EmployeeName = "Alice" },
                new BinarySerialization.Employee { EmployeeName = "Bob" }
            }
            };
            var filePath = "testBinary.dat";

            // Act
            BinarySerialization.Program.SerializeToBinaryFile(originalDepartment, filePath);
            var deserializedDepartment = BinarySerialization.Program.DeserializeFromBinaryFile(filePath);

            // Assert
            Assert.Equal(originalDepartment.DepartmentName, deserializedDepartment.DepartmentName);
            Assert.Equal(originalDepartment.Employees.Count, deserializedDepartment.Employees.Count);
            Assert.Equal(originalDepartment.Employees[0].EmployeeName, deserializedDepartment.Employees[0].EmployeeName);
        }

        [Fact]
        public void TestXmlSerialization()
        {
            // Arrange
            var originalDepartment = new XMLSerialization.Department
            {
                DepartmentName = "Marketing",
                Employees = new List<XMLSerialization.Employee>
            {
                new XMLSerialization.Employee { EmployeeName = "Carl" },
                new XMLSerialization.Employee { EmployeeName = "David" }
            }
            };
            var filePath = "testXml.xml";

            // Act
            XMLSerialization.Program.SerializeToXmlFile(originalDepartment, filePath);
            var deserializedDepartment = XMLSerialization.Program.DeserializeFromXmlFile(filePath);

            // Assert
            Assert.Equal(originalDepartment.DepartmentName, deserializedDepartment.DepartmentName);
            Assert.Equal(originalDepartment.Employees.Count, deserializedDepartment.Employees.Count);
            Assert.Equal(originalDepartment.Employees[0].EmployeeName, deserializedDepartment.Employees[0].EmployeeName);
        }

        [Fact]
        public void TestJsonSerialization()
        {
            // Arrange
            var originalDepartment = new JSONSerialization.Department
            {
                DepartmentName = "Sales",
                Employees = new List<JSONSerialization.Employee>
            {
                new JSONSerialization.Employee { EmployeeName = "Emma" },
                new JSONSerialization.Employee { EmployeeName = "Frank" }
            }
            };
            var filePath = "testJson.json";

            // Act
            JSONSerialization.Program.SerializeToJsonFile(originalDepartment, filePath);
            var deserializedDepartment = JSONSerialization.Program.DeserializeFromJSONFile(filePath);

            // Assert
            Assert.Equal(originalDepartment.DepartmentName, deserializedDepartment.DepartmentName);
            Assert.Equal(originalDepartment.Employees.Count, deserializedDepartment.Employees.Count);
            Assert.Equal(originalDepartment.Employees[0].EmployeeName, deserializedDepartment.Employees[0].EmployeeName);
        }
    }
}