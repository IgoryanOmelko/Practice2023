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
using System.Drawing;
using System.Drawing.Imaging;

namespace GiveGood.Pages
{
    /// <summary>
    /// Логика взаимодействия для Profiles.xaml
    /// </summary>
    public partial class Profiles : Page
    {
        int selectedDistrict;
        List<Model.User> users;
        List<UserEx> usersEx;
        int beforeCount;
        public Profiles()
        {
            InitializeComponent();
            InitializeComponent();
            beforeCount = Helper.DB.Action.ToList().Count;
            List<string> values = new List<string>();
            if (Classes.User.roleID == 1)
            {
                AddUser.IsEnabled = false;
                AddUser.Visibility = Visibility.Hidden;
            }

            

            List<string> values2 = new List<string>();
            List<Model.District> districts = Helper.DB.District.ToList();
            foreach (Model.District item in districts)
            {
                string s = item.DistrictName;
                values2.Add(s);
            }
            values2.Insert(0, "Все районы");
            DistrictFilt.ItemsSource = values2;
            DistrictFilt.SelectedIndex = 0;
            selectedDistrict = DistrictFilt.SelectedIndex;
            Updatelist();
        }
        /// <summary>
        /// Действия при загрузке страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Updatelist();
        }
        /// <summary>
        /// Метод выполняет получение списка акции из базы данных
        /// </summary>
        /// <returns>Список акций, если акции найдены, null, если произошла ошибка чтения БД</returns>
        private List<Model.User> GetUsers()
        {
            List<Model.User> result = new List<Model.User>();
            try
            { 
                result = Helper.DB.User.Where(x => x.RoleID == 3).ToList();
                result = result.OrderBy(x => x.UserSurname).ToList();
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
        
        /// <summary>
        /// Метод выполняет получение списка акций, район которых соответствует входному значению
        /// </summary>
        /// <param name="value">Значение параметра отбора (Идентификатор)</param>
        private void DistrictFilter(int value)
        {
            if (value > 0)
            {
                try
                {
                    users = users.Where(x => x.District.First().DistrictID == value).ToList();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else
            {
                return;
            }


        }
        /// <summary>
        /// Метод выполняет получение списка акций, наименование, описание или район которых соответствует входному значению
        /// </summary>
        /// <param name="value">Значение параметра отбора (Фрагмент строки)</param>
        private void SearchFilter(string value)
        {
            try
            {
                users = users.Where(x => x.UserSurname.Contains(value) || x.UserName.Contains(value) || x.UserPatronymic.Contains(value) || x.District.First().DistrictName.Contains(value)).ToList();
            }
            catch (Exception)
            {
                return;
            }

        }
        /// <summary>
        /// Метод выполняет получение списка акций, организотор которых соответствует текущему пользователю
        /// </summary>
        /// <param name="value">Показатель соответствия текущего пользователя организатору акции (Булево значение)</param>
        private void OwnedFilter(bool value)
        {
            try
            {
                if (value)
                {
                    users = users.Where(x => x.District.First()== Classes.User.district).ToList();
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        /// <summary>
        /// Метод выполняет обновление списка акций, выводимых на форму с учетом установленных параметров сортировки
        /// </summary>
        private void Updatelist()
        {
            try
            {
                beforeCount = Helper.DB.User.Where(x=>x.RoleID ==3).ToList().Count;
                users = GetUsers();
                SearchFilter(Search.Text);
                OwnedFilter(isOwned.IsChecked.Value);
                DistrictFilter(selectedDistrict);
                convertToEx();
                ActionList.ItemsSource = usersEx;
                int displayed = users.Count;
                Found.Text = $"{displayed} из {beforeCount}";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Метод выполняет конвертацию списка акций, полученного из базы данных, в список, отображаемых на форме
        /// </summary>
        private void convertToEx()
        {
            usersEx = new List<UserEx>();
            foreach (Model.User item in users)
            {
                try
                {
                    UserEx ue = new UserEx();
                    ue.Fio = $"{item.UserSurname} {item.UserName} {item.UserPatronymic}";
                    ue.District2 = item.District.First().DistrictName;
                    ue.Bdate = Convert.ToDateTime(item.BirthDate).ToShortDateString();
                    string path = Environment.CurrentDirectory + $@"\images\{item.Photo}";
                    if (File.Exists(path))
                    {
                        BitmapImage image = new BitmapImage();
                        image.BeginInit();
                        image.UriSource = new Uri(path);
                        image.EndInit();
                        ue.Photo2 = image;
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
                        ue.Photo2 = bitmapImage;
                    }
                    usersEx.Add(ue);
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }
        /// <summary>
        /// Действия по нажатию на кнопку редактирования пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (Classes.User.roleID == 1)
            {
                MessageBox.Show("Действие недоступно", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Model.User currentUser;
            int selectedIndex = -1;
            try
            {   
                selectedIndex = ActionList.Items.IndexOf((Object)(sender as Button).DataContext);
                int currentUserID = users.ElementAt(selectedIndex).UserID;
                currentUser = users.ElementAt(selectedIndex);
                if (currentUser.District.First().DistrictID!=Classes.User.district.DistrictID)
                {
                    MessageBox.Show("Вы можете редаткироватьтолько принадлежащих вам волонтеров", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                View.ProfileEdit profileEditWindow = new View.ProfileEdit(currentUser);
                Window menu = Window.GetWindow(this);
                menu.Hide();
                profileEditWindow.ShowDialog();
                Updatelist();
                menu.Show();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        /// <summary>
        /// Действия при наборе текста в строке поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Updatelist();
        }
        /// <summary>
        /// Действия по нажатию на флажок соответсвия менеджера волонтеров волонтерам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isOwned_Checked(object sender, RoutedEventArgs e)
        {
            Updatelist();
        }
        /// <summary>
        /// Действия при изменении выбранного значения выпадающего списка сортировки по району
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistrictFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDistrict = DistrictFilt.SelectedIndex;
            Updatelist();
        }
        /// <summary>
        /// Действия по нажатию на кнопку добавления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                View.ProfileEdit profileEditWindow = new View.ProfileEdit(true);
                Window menu = Window.GetWindow(this);
                menu.Hide();
                profileEditWindow.ShowDialog();
                Updatelist();
                menu.Show();
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
    partial class UserEx : Model.User
    {
        private BitmapImage photo;
        private string fio;
        private string district;
        private string bdate;
        public string Fio{
            get
            {
                return fio;
            }
            set 
            {
                fio = value;
            }
        }
        public string District2
        {
            get
            {
                return district;
            }
            set
            {
                district = value;
            }
        }
        public string Bdate{
            get
            {
                return bdate;
            }
            set 
            {
                bdate = value;
            }
        }
        public BitmapImage Photo2
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
        }
    }
}

