using System.Runtime.Serialization.Formatters.Binary;

namespace Task2_ISerializable_Binary;
public class Program
{
    static void Main(string[] args)
    {
        string filePath = "user.dat";

        //Create a Useraccount
        var user = new UserAccount
        {
            UserName = "Test",
            Password = "password"
        };

        Console.WriteLine("Before binary serialization");
        Console.WriteLine(user);

        //Serialize
        Serialize(user, filePath);

        //Deserialize the person object back from the file
        var deserializedUser = Deserialize(filePath);
        Console.WriteLine("n After deserialization: ");
        Console.WriteLine(deserializedUser);
    }

    public static void Serialize(UserAccount user, string filePath)
    {
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, user);
            Console.WriteLine("\nUserAccount object has been serialized to " + filePath);
        }
    }

    public static UserAccount Deserialize(string filePath)
    {
        using (var stream = new FileStream(filePath, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            var person = (UserAccount)formatter.Deserialize(stream);
            Console.WriteLine("\nPerson object has been deserialized from " + filePath);
            return person;
        }
    }
}