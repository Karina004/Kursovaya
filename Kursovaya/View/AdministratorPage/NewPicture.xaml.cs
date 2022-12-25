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
    /// Логика взаимодействия для NewPicture.xaml
    /// </summary>
    public partial class NewPicture : Page
    {
        public NewPicture()
        {
            InitializeComponent();

        }



        private void BtnClose3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameNavigate.FrameCore.Navigate(new AdministratorPage());
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameBox.Text) ||
               string.IsNullOrEmpty(YearBox.Text) ||
               string.IsNullOrEmpty(AuthorBox.Text) ||
               string.IsNullOrEmpty(DateOfBirthBox.Text))
               
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                FrameNavigate.DB.Picture.Add(new Picture
                {
                    Name = NameBox.Text,
                    YearOfPublication = YearBox.Text,
                    ArtistName = AuthorBox.Text,
                    DateOfBirth=DateOfBirthBox.Text
                });

                await FrameNavigate.DB.SaveChangesAsync();
                MessageBox.Show("Картина добавлена!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
