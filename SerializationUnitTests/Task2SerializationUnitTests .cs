using BinarySerialization;
using JSONSerialization;
using XMLSerialization;


namespace SerializationUnitTests
{
    public class Task2SerializationUnitTests
    {
        [Fact]
        public void CustomTestBinarySerialization()
        {
            // Arrange
            var userAccount = new Task2_ISerializable_Binary.UserAccount
            {
                UserName = "TesUser",
                Password = "12345"
            };
            var filePath = "userAccount.dat";

            // Act
            Task2_ISerializable_Binary.Program.Serialize(userAccount, filePath);
            var deserializedUserAccount = Task2_ISerializable_Binary.Program.Deserialize(filePath);

            // Assert
            Assert.Equal(userAccount.UserName, deserializedUserAccount.UserName);
            Assert.Equal(userAccount.Password, deserializedUserAccount.Password);
        }
    }
}