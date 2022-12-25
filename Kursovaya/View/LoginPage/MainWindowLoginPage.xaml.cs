using Kursovaya.Core;
using Kursovaya.Model;
using Kursovaya.View.AdministratorPage;
using Kursovaya.View.ClientPages;
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

namespace Kursovaya.View.LoginPage
{
    public partial class MainWindowLoginPage : Page
    {
        public MainWindowLoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Tblogin.Text))
            {
                MessageBox.Show("Ошибка ввода данных!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    User userModel = FrameNavigate.DB.User.FirstOrDefault(u =>
                u.Login == Tblogin.Text && u.Password == PbPassword.Password);

                    if (userModel == null)
                    {
                        MessageBox.Show("Ошибка данных",
                            "Системное сообщение",
                            MessageBoxButton.OK, 
                            MessageBoxImage.Error);
                    }
                    switch (userModel.IDRole) 
                    {
                        case 2:
                            FrameNavigate.FrameCore.Navigate(new MainClientPage());
                            break;
                        case 1:
                            FrameNavigate.FrameCore.Navigate(new AdministratorPage.AdministratorPage());
                            break;

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
    }
}
