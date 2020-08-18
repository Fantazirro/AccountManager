using Logic.Models;
using Logic.Saver;
using System.Collections.Generic;
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
            bool IsAccountExists = Accounts.Exists(a => (a.Service == service) && (a.Login == login));

            if (!IsAccountExists)
            {
                if(string.IsNullOrEmpty(service) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
                {
                    Message("Переданные данные некорректны");
                    return;
                }
                UserData user = new UserData(service, login, pass);
                Accounts.Add(user);
                Save();

                Message("Ваш аккаунт был добавлен в базу данных");
            }
            else
            {
                Message("Ошибка: Этот аккаунт уже хранится в базе данных");
            }
        }

        public Dictionary<string, string> Get(string service)
        {
            bool IsAccountsExists = Accounts.Exists(l => l.Service == service);

            if (!IsAccountsExists)
            {
                Message("Ошибка: Аккаунтов этого сервиса нет в базе данных");
                return new Dictionary<string, string>();
            }
            else
            {
                IEnumerable<UserData> accounts = Accounts.Where(l => l.Service == service);

                Dictionary<string, string> accountsDict = new Dictionary<string, string>();
                foreach (UserData acc in accounts)
                {
                    accountsDict.Add(acc.Login, acc.Password);
                }

                return accountsDict;
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

            Save();
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