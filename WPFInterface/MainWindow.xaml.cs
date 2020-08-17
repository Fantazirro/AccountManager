using System.Windows;
using Logic.Resources;
using Logic.Controllers;
using System.Collections.Generic;
using System.Windows.Controls;
using WPFInterface.Models;

namespace WPFInterface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller = new Controller();
        string currentService = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            InitializeText();
            controller.Message += GetMessage;
        }

        private void InitializeText()
        {
            addAccText.Text = Text.AddAccount;
            addServiceText.Text = Text.EnterService;
            addLoginText.Text = Text.EnterLogin;
            addPassText.Text = Text.EnterPass;

            getServiceText.Text = Text.EnterService;
            getAccText.Text = Text.GetAccounts;

            deleteAccText.Text = Text.DeleteAccount;
            deleteServiceText.Text = Text.EnterService;
            deleteLoginText.Text = Text.EnterLogin;

            GetAccount.Content = Text.Get;
            DeleteAccount.Content = Text.Delete;
        }

        private void addAccount_Click(object sender, RoutedEventArgs e)
        {
            string service = serviceField.Text;
            string login = loginField.Text;
            string pass = passField.Text;

            controller.Add(service, login, pass);

            if (currentService == service) GetAccountsData(service);
        }

        private void GetMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            string service = deleteServiceField.Text;
            string login = deleteLoginField.Text;           
           
            controller.Delete(service, login);

            if (currentService == service) GetAccountsData(service);
        }

        private void GetAccount_Click(object sender, RoutedEventArgs e)
        {
            string service = getServiceField.Text;
            currentService = service;

            GetAccountsData(service);      
        }

        private void GetAccountsData(string service)
        {
            Dictionary<string, string> accounts = controller.Get(service);

            dataTable.Items.Clear();
            foreach (var item in accounts)
            {
                dataTable.Items.Add(new DataGridModel() { Login = item.Key, Password = item.Value });
            } 
        }
    }
}