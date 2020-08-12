using Logic.Models;
using Logic.Saver;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Logic.Controllers
{
    public class Controller
    {
        private List<UserData> Accounts { get; }
        private IDataSaver FileSaver = new SerializeSaver();

        public delegate void MessageHandler(string message);
        public event MessageHandler Message;

        public Controller()
        {
            Accounts = Load();
        }

        public void Add(string service, string login, string pass)
        {
            var acc = Accounts.Exists(a => (a.Service == service) && (a.Login == login));

            if (!acc)
            {
                var user = new UserData(service, login, pass);
                Accounts.Add(user);
                Save();

                Message("Ваш аккаунт был добавлен в базу данных");
            }
            else
            {
                Message("Ошибка: Этот аккаунт уже хранится в базе данных");
            }
        }

        public void Get(string service)
        {
            bool IsAccountsExist = Accounts.Exists(l => l.Service == service);

            if (!IsAccountsExist) Message("Ошибка: Аккаунтов этого сервиса нет в базе данных");
            else
            {
                var accounts = Accounts.Where(l => l.Service == service);

                Message($"Все аккаунты сервиса {service}:");
                foreach (var acc in accounts)
                {
                    Message($"{acc.Login} - {acc.Password}");
                }
            }
        }

        public void Delete(string service, string login)
        {
            bool IsAccountExist = Accounts.Exists(a => (a.Service == service) && (a.Login == login));

            if(IsAccountExist)
            {
                UserData account = Accounts.FirstOrDefault(a => (a.Service == service) && (a.Login == login));
                Accounts.Remove(account);
                Message("Аккаунт удалён");
            }
            else
            {
                Message("Такого аккаунта нет в базе данных");
            }
        }

        public void Save()
        {
            FileSaver.Save(Accounts);
        }

        public List<UserData> Load()
        {
            return FileSaver.Load() ?? new List<UserData>();
        }
    }
}