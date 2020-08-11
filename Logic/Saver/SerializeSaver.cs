using Logic.Models;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Logic.Saver
{
    class SerializeSaver : IDataSaver
    {
        private const string ACCOUNTS_FILENAME = "accounts.dat";
        public List<UserData> Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(ACCOUNTS_FILENAME, FileMode.OpenOrCreate))
            {
                if (stream.Length > 0 && formatter.Deserialize(stream) is List<UserData> accounts) return accounts;
                else return new List<UserData>();
            }
        }

        public void Save(List<UserData> data)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(ACCOUNTS_FILENAME, FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, data);
            }
        }
    }
}