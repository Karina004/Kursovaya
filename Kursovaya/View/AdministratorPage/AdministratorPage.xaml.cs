using Kursovaya.Core;
using Kursovaya.Model;
using Kursovaya.View.ClientPages;
using Kursovaya.View.LoginPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Kursovaya.View.AdministratorPage
{
    /// <summary>
    /// Логика взаимодействия для AdministratorPage.xaml
    /// </summary>
    public partial class AdministratorPage : Page
    {
        public AdministratorPage()
        {
            InitializeComponent();

            FrameNavigate.FrameCore = FrameAdmin;
            InfoPic.ItemsSource = FrameNavigate.DB.Picture.ToList();
            InfoClient.ItemsSource = FrameNavigate.DB.Client.ToList();
            InfoArtist.ItemsSource = FrameNavigate.DB.Picture.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameCore.Navigate(new MainWindowLoginPage());
        }

        private void BtnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameNavigate.FrameCore.Navigate(new MainWindowLoginPage());
        }

       
        private void BtnDeletePicture_Click(object sender, RoutedEventArgs e)
        {
            int IdPicture = (InfoPic.SelectedItem as Picture).IDPicture;
            var result = MessageBox.Show("Удалить информацию о картине?",
                                         "Системное сообщение",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Picture picture = (from b in FrameNavigate.DB.Picture where b.IDPicture == IdPicture select b).SingleOrDefault();
                FrameNavigate.DB.Picture.Remove(picture);
                FrameNavigate.DB.SaveChanges();
                InfoPic.ItemsSource = FrameNavigate.DB.Picture.OrderBy(b => b.IDPicture).ToList();
            }

        }

        private void BtnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            int IdClient = (InfoClient.SelectedItem as Client).IDClient;
            var result = MessageBox.Show("Удалить информацию о клиенте?",
                                         "Системное сообщение",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Client client = (from b in FrameNavigate.DB.Client where b.IDClient == IdClient select b).SingleOrDefault();
                FrameNavigate.DB.Client.Remove(client);
                FrameNavigate.DB.SaveChanges();
                InfoClient.ItemsSource = FrameNavigate.DB.Client.OrderBy(b => b.IDClient).ToList();
            }
        }

       

        private void BtnNewPicture_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameCore.Navigate(new NewPicture());
        }

        private void BtnNewClient_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameCore.Navigate(new NewClient());
        }
    }
}
