using Kursovaya.Core;
using Kursovaya.Model;
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

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FrameNavigate.FrameCore = MainFrame;
            MainFrame.Navigate(new MainWindowLoginPage());


            FrameNavigate.DB = new ArtGallery3Entities();
        }

        

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            {
                DragMove();
            }
        }
    }
}
