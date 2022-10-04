using Chat1.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Chat1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void authButton_Click(object sender, RoutedEventArgs e)
        {
           var authUser = ClassHelper.AppData.Context.User.ToList().
           Where(i => i.Login == txtLogin.Text && i.Passvord == pswPassword.Password).FirstOrDefault();
            if (authUser != null)
            {
                UserWindow mainWindow = new UserWindow(authUser);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                txtError.Text = "Введеный пользователь не существует!";
            }
        }
    }

}
