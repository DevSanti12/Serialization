using BinarySerialization;
using JSONSerialization;
using XMLSerialization;


namespace SerializationUnitTests
{
    public class Task2SerializationUnitTests
    {
        [Fact]
        public void DeepClone_ShouldHandleEmptyList()
        {
            // Arrange
            var originalDepartment = new Department { DepartmentName = "Empty Department" };

            // Act
            var clonedDepartment = Program.DeepClone(originalDepartment);

            // Assert
            Assert.NotSame(originalDepartment, clonedDepartment);
            Assert.Equal(originalDepartment.DepartmentName, clonedDepartment.DepartmentName);
            Assert.Empty(clonedDepartment.Employees);
        }
        Account.Password, deserializedUserAccount.Password);
    }
}