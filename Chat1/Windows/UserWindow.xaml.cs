using Chat1.EF;
using Microsoft.Win32;
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
using System.Windows.Shapes;
using Chat1.ClassHelper;

using System.IO;

namespace Chat1.Windows
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    
    public partial class UserWindow : Window
    {
        
        EF.User editUser = new EF.User(); 
        string photostrl;
        public UserWindow(EF.User user)
        {
            InitializeComponent();
            editUser = user;
            UserAppDate(user);
        }
        public void UserAppDate (EF.User client)
        {
            NicName.Text = client.Name;
            client.idPhotoActive = 1;
            if (client.Photo != null)
            {
                using (MemoryStream stream = new MemoryStream(client.Photo))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    PhotoUser.Source = bitmapImage;
                }
            }
        }


        private void btnEntrance_Click(object sender, RoutedEventArgs e)
        {
            Chat chatWindow = new Chat();
            chatWindow.Show();
            this.Close();
            bool a = true;
            chatWindow.ideshka(a);
            try
                {
                    editUser.Name = NicName.Text;

                    if (photostrl != null)
                    {
                        editUser.Photo = File.ReadAllBytes(photostrl);
                    }
                    ClassHelper.AppData.Context.SaveChanges();
                    this.Close();
            }
            catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                
                }
            EF.User client = new EF.User();
            client.ISActive = true;
        }


        private void btnPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF";
            if (openFile.ShowDialog() == true)
            {
                PhotoUser.Source = new BitmapImage(new Uri(openFile.FileName));
                photostrl = openFile.FileName;
            }
        }
    }
}
