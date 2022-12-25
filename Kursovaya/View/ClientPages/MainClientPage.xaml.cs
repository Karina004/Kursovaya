using Kursovaya.Core;
using Kursovaya.View.LoginPage;
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

namespace Kursovaya.View.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для MainClientPage.xaml
    /// </summary>
    public partial class MainClientPage : Page
    {
        public MainClientPage()
        {
            InitializeComponent();
            InfoPic.ItemsSource = FrameNavigate.DB.Picture.ToList();
            
        }

        private void InfoPic_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameNavigate.FrameCore.Navigate(new MainWindowLoginPage());
        }

        private void BtnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void InfoPic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void request1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
