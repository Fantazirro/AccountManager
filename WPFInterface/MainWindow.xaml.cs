using System.Windows;
using Logic.Resources;
using Logic.Controllers;

namespace WPFInterface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller = new Controller();

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
            getLoginText.Text = Text.EnterLogin;
        }

        private void addAccount_Click(object sender, RoutedEventArgs e)
        {
            string service = serviceField.Text;
            string login = loginField.Text;
            string pass = passField.Text;

            controller.Add(service, login, pass);
        }

        private void GetMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            string service = getServiceField.Text;
            string login = getLoginField.Text;
           
            controller.Delete(service, login);
        }
    }
}
