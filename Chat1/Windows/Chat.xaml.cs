using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Chat1.EF;


namespace Chat1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        EF.Chat editText = new EF.Chat();
        private bool c;
        public void ideshka(bool a)
        {
            c = a;
        }
        public Chat()
        {
            InitializeComponent();
            lvClientList.ItemsSource = ClassHelper.AppData.Context.User.Where(i => i.IsDeleted == false).ToList();
            lvChatList.ItemsSource = ClassHelper.AppData.Context.Massage.Where(i => i.IsDeleted == false).ToList();
            Filter();
            EF.ImageStatus imageStatus = new ImageStatus();
            EF.User client = new User();
        }


        public void ChatAppDate(EF.Massage massage)
        {
            
            ChatText.Text = massage.Text;
        }
        private void Filter()
        {
            List<EF.User> ListClient = new List<EF.User>();
            ListClient = ClassHelper.AppData.Context.User.Where(i => i.IsDeleted == false).ToList();
            
        }

        private void lvClientList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int a = lvClientList.SelectedIndex + 1;
            if (lvClientList.SelectedItem is EF.User)
            {
                var clt = lvClientList.SelectedItem as EF.User;
                lvChatList.ItemsSource = ClassHelper.AppData.Context.Massage.Where(i => i.IsDeleted == false && i.IDChat == a).ToList();
            }
            Filter();
        }

        private void lvClientList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                try
                {
                    if (lvClientList.SelectedItem is EF.User)
                    {
                        var resmsg = MessageBox.Show("Удалить клиента?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resmsg == MessageBoxResult.No)
                        {
                            return;
                        }
                        var clt = lvClientList.SelectedItem as EF.User;
                        clt.IsDeleted = true;
                        ClassHelper.AppData.Context.SaveChanges();
                        MessageBox.Show("Клиент успешно удален", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                        Filter();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void lvChatList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Filter();
        }

        private void lvChatList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                try
                {
                    if (lvClientList.SelectedItem is EF.Massage)
                    {
                        var resmsg = MessageBox.Show("Удалить клиента?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resmsg == MessageBoxResult.No)
                        {
                            return;
                        }
                        var clt = lvClientList.SelectedItem as EF.Massage;
                        clt.IsDeleted = true;
                        ClassHelper.AppData.Context.SaveChanges();
                        MessageBox.Show("Клиент успешно удален", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                        Filter();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }



        private void btnPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF";
            if (openFile.ShowDialog() == true)
            {
                EF.Massage messagePhoto = new Massage();
                messagePhoto.Photo = File.ReadAllBytes(openFile.FileName);
                messagePhoto.IDChat = 1;
                messagePhoto.Text = null;
                messagePhoto.IsDeleted = false;
                AppData.Context.Massage.Add(messagePhoto);
                AppData.Context.SaveChanges();
            }
            Filter();
        }

        private void btnSending_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EF.Massage messageText = new Massage();
                messageText.Photo = null;
                messageText.IDChat = 1;
                messageText.Text = ChatText.Text;
                messageText.IsDeleted = false;
                AppData.Context.Massage.Add(messageText);
                AppData.Context.SaveChanges();
                ClassHelper.AppData.Context.SaveChanges();
                lvChatList.ItemsSource = null;
                lvChatList.ItemsSource = ClassHelper.AppData.Context.Massage.Where(i => i.IsDeleted == false).ToList();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            EF.User client = new EF.User();
            client.ISActive = true;
        }


        private void Grid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            InitializeComponent();
            lvClientList.ItemsSource = ClassHelper.AppData.Context.User.ToList();
            lvChatList.ItemsSource = ClassHelper.AppData.Context.Massage.ToList();
            MessageBox.Show("Yua Zaebalsa");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            this.Close();
        }
    }
}
