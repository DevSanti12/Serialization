using DeepCloningApp;


namespace SerializationUnitTests
{
    public class DeepCloningAppUnitTests
    {
        [Fact]
        public void DeepClone_ShouldHandleEmptyList()
        {
            // Arrange
            var originalDepartment = new DeepCloningApp.Department { DepartmentName = "Empty Department" };

            // Act
            var clonedDepartment = DeepCloningApp.Program.DeepClone(originalDepartment);

            // Assert
            Assert.NotSame(originalDepartment, clonedDepartment);
            Assert.Equal(originalDepartment.DepartmentName, clonedDepartment.DepartmentName);
            Assert.Empty(clonedDepartment.Employees);
        }
    }
}