using System.Runtime.Serialization;

namespace Task2_ISerializable_Binary
{
    [Serializable]
    public class UserAccount : ISerializable
    {
        public string UserName {  get; set; }
        public string Password { get; set; }

        public UserAccount() { } //default constructor
        
        //constructor that deserializes data from a provided SerializationInfo
        protected UserAccount(SerializationInfo info, StreamingContext context)
        {
            UserName = info.GetString("Name");
            Password = info.GetString("Password");
        }
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //Customized how to data is serialized
            info.AddValue("Name", UserName);
            info.AddValue("Password", Password);
        }

        public override string ToString()
        {
            return $"UserName: {UserName}, Password: {Password}";
        }
    }
}
