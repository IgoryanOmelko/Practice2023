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
using Model = GiveGood.Classes.Model;
using Helper = GiveGood.Classes.DBHelper;
using System.IO;
using System.Media;
using System.Drawing;
using System.Drawing.Imaging;

namespace GiveGood.Pages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        Model.User User;
        string districtName;
        int userID;
        public Profile()
        {
            InitializeComponent();
        }
        public Profile(int userID)
        {
            if(Classes.User.userID<0)
            {
                Window menu = Window.GetWindow(this);
                menu.Close();
            }
            
            this.userID = userID;
            InitializeComponent();
            User = new Model.User();
            try
            {
                User = Helper.DB.User.Where(x => x.UserID == userID).ToList().First();
                districtName = User.District.First().DistrictName;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                //throw;
                return;
            }
            Surname.Text = User.UserSurname;
            Name.Text = User.UserName;
            Patronymic.Text = User.UserPatronymic;
            Role.Text = User.Role.RoleName;
            string path = Environment.CurrentDirectory + $@"\images\{User.Photo}";
            if (File.Exists(path))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(path);
                image.EndInit();
                ProfileImage.Source = image;
            }
            else
            {
                BitmapImage bitmapImage;
                Bitmap bmp = new Bitmap(Properties.Resources.placeholder);
                using (var memory = new MemoryStream())
                {
                    bmp.Save(memory, ImageFormat.Png);
                    memory.Position = 0;
                    bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();

                    
                }
                ProfileImage.Source = bitmapImage;
            }
            Phone.Text = User.Phone;
            District.Text = districtName;
            Phone.Text = User.Phone;
            Email.Text = User.Email;
            BirthDate.Text = User.BirthDate.ToShortDateString();

        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.User currentUser = Helper.DB.User.Where(x => x.UserID == Classes.User.userID).FirstOrDefault();
                View.ProfileEdit profileEditWindow = new View.ProfileEdit(currentUser);
                Window menu = Window.GetWindow(this);
                menu.Hide();
                profileEditWindow.ShowDialog();
                if(Classes.User.userID<0)
                {
                    menu.Close();
                    return;
                }
                menu.Show();
            }
            catch (Exception ex)
            {

                return;
            }
        }
    }
}
