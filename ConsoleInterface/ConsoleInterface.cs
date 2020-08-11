﻿using Logic.Controllers;
using System;
using Logic.Resources;

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
                Console.WriteLine($"3. {Text.Exit}");
                Console.Write(Text.Enter);

                var answer = Console.ReadKey().Key;
                Console.Clear();

                if (answer == ConsoleKey.D1)
                {
                    AddAccount();
                    Console.Clear();
                }
                else if (answer == ConsoleKey.D2)
                {
                    LoadAccounts();
                    Console.Clear();
                }
                else if (answer == ConsoleKey.D3) Environment.Exit(0);
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

        private void LoadAccounts()
        {
            Console.Write(Text.EnterService);
            string service = Console.ReadLine();

            Console.Clear();
            controller.Get(service);

            Console.WriteLine($"\n{Text.PressAnyKey}");
            Console.ReadKey();
        }

        void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}