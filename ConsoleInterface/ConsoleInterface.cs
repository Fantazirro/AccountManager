using Logic.Controllers;
using System;
using Logic.Resources;
using System.Collections.Generic;

namespace ConsoleInterface
{
    public class ConsoleInterface
    {
        Controller controller = new Controller();
        public void Use()
        {
            controller.Message += WriteLine;

            Console.WriteLine(Text.Greeting);

            while (true)
            {
                Console.WriteLine(Text.ChooseAction);
                Console.WriteLine($"1. {Text.AddAccount}");
                Console.WriteLine($"2. {Text.GetAccounts}");
                Console.WriteLine($"3. {Text.DeleteAccount}");
                Console.WriteLine($"4. {Text.Exit}");
                Console.Write(Text.Enter);

                ConsoleKey answer = Console.ReadKey().Key;
                Console.Clear();

                if (answer == ConsoleKey.D1)
                {
                    AddAccount();
                    Console.Clear();
                }
                else if (answer == ConsoleKey.D2)
                {
                    GetAccounts();
                    Console.Clear();
                }
                else if (answer == ConsoleKey.D3)
                {
                    DeleteAccount();
                    Console.Clear();
                }
                else if (answer == ConsoleKey.D4) Environment.Exit(0);
                else
                {
                    Console.WriteLine(Text.IncorrectInputData);
                    Console.WriteLine();
                }
            }
        }

        private void AddAccount()
        {
            Console.Write(Text.EnterService);
            string service = Console.ReadLine();

            Console.Write(Text.EnterLogin);
            string login = Console.ReadLine();

            Console.Write(Text.EnterPass);
            string pass = Console.ReadLine();

            Console.Clear();
            controller.Add(service, login, pass);

            Console.WriteLine($"\n{Text.PressAnyKey}");
            Console.ReadKey();
        }

        private void GetAccounts()
        {
            Console.Write(Text.EnterService);
            string service = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"Все аккаунты сервиса {service}:");
            Dictionary<string, string> accounts = controller.Get(service);
            foreach (var item in accounts)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine($"\n{Text.PressAnyKey}");
            Console.ReadKey();
        }

        private void DeleteAccount()
        {
            Console.Write(Text.EnterService);
            string service = Console.ReadLine();

            Console.Write(Text.EnterLogin);
            string login = Console.ReadLine();

            Console.Clear();
            controller.Delete(service, login);

            Console.WriteLine($"\n{Text.PressAnyKey}");
            Console.ReadKey();
        }

        void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}