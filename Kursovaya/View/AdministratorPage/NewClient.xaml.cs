using Kursovaya.Core;
using Kursovaya.Model;
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

namespace Kursovaya.View.AdministratorPage
{
    /// <summary>
    /// Логика взаимодействия для NewClient.xaml
    /// </summary>
    public partial class NewClient : Page
    {
        public NewClient()
        {
            InitializeComponent();
        }

        private void BtnClose3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameNavigate.FrameCore.Navigate(new AdministratorPage());
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if
                (string.IsNullOrEmpty(ClientBox.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                FrameNavigate.DB.Client.Add(new Client
                {
                    FIO = ClientBox.Text,
                    
                });

                await FrameNavigate.DB.SaveChangesAsync();
                MessageBox.Show("Клиент добавлен!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
