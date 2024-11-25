using System.Linq;
using System.Windows;

namespace avtoServ
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        public static string authorizationRole;

        public static string GetRole(string login, string password)
        {
            var users = STOEntities.GetContext().Users.FirstOrDefault(a => a.Login_ == login && a.Password_ == password);
            if (users != null)
            {
                return authorizationRole = users.id_Role_.ToString();
            }   

            return null;
        }

        private void Button_Account(object sender, RoutedEventArgs e)
        {
            if (GetRole(textBoxLogin.Text, textBoxPassword.Text) == null)
            {
                MessageBox.Show("Данные введены не корректно!", "Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                MessageBox.Show(authorizationRole, "!!!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Button_Click_Out(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
