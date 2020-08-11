using System;

namespace Logic.Models
{
    [Serializable]
    public class UserData
    {
        public int ID { get; set; }

        public string Service { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public UserData() { }
        public UserData(string service, string login, string password)
        {
            Service = service;
            Login = login;
            Password = password;
        }

        public override string ToString()
        {
            return $"{Service} - {Login}";
        }
    }
}