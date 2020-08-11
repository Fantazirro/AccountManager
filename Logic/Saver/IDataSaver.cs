using Logic.Models;
using System.Collections.Generic;

namespace Logic.Saver
{
    interface IDataSaver
    {
        void Save(List<UserData> data);
        List<UserData> Load();
    }
}