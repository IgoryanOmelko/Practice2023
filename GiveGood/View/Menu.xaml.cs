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
using GiveGood.Pages;
using Model = GiveGood.Classes.Model;
using Helper = GiveGood.Classes.DBHelper;

namespace GiveGood.View
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        Pages.Profile pageProfile;
        Pages.Profiles pageProfiles;
        Pages.Actions pageActions;
        Pages.ActionsPart pageActionsPart;
        public Menu()
        {   
            if(Classes.User.userID<0)
            {
                Close();
            }
            pageProfile = new Pages.Profile(Classes.User.userID);
            pageActions = new Pages.Actions();
            InitializeComponent();
            switch (Classes.User.roleID)
            {
                case 2:
                    buttonActions.IsEnabled = false;
                    buttonActions.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    buttonVolunteers.IsEnabled = false;
                    buttonVolunteers.Visibility = Visibility.Hidden;

                    break;
                default:
                    break;
            }
            
            ContentContainer.Content = pageProfile;
        }
        /// <summary>
        /// Действия по нажатию на кнопку профиля пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonProfile_Click(object sender, RoutedEventArgs e)
        {
            pageProfile = new Pages.Profile(Classes.User.userID);
            ContentContainer.Content = pageProfile;
        }
        /// <summary>
        /// Действия по нажатию на кнопку списка акций
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonActions_Click(object sender, RoutedEventArgs e)
        {
            if(Classes.User.roleID ==3)
            {
                pageActionsPart = new Pages.ActionsPart();
                ContentContainer.Content = pageActionsPart;
            }
            else
            {
                pageActions = new Pages.Actions();
                ContentContainer.Content = pageActions;
            }
            
        }
        /// <summary>
        /// Действия при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Classes.User.userID < 0)
            {
                Close();
            }
            pageProfile = new Pages.Profile(Classes.User.userID);
            pageActions = new Pages.Actions();
            switch (Classes.User.roleID)
            {
                case 2:
                    buttonActions.IsEnabled = false;
                    buttonActions.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    buttonVolunteers.IsEnabled = false;
                    buttonVolunteers.Visibility = Visibility.Hidden;

                    break;    
            default:
                    break;
            }
            Fio.Text = $"{Classes.User.userSurname} {Classes.User.userName} {Classes.User.userPatronymic}";
        }
        /// <summary>
        /// Действия при нажатии на кнопку действия (кнопка назад)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAction_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Window w = App.Current.MainWindow;
            w.Show();
        }

        /// <summary>
        /// Действия по нажатию на кнопку списка волонтеров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonVolunteers_Click(object sender, RoutedEventArgs e)
        {
            pageProfiles = new Pages.Profiles();
            ContentContainer.Content = pageProfiles;

        }
    }
}
