using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using IO = System.IO;
using Image = System.Drawing.Image;
using Model = GiveGood.Classes.Model;
using Helper = GiveGood.Classes.DBHelper;
using System.Drawing.Imaging;
using System.IO;

namespace GiveGood.View
{
    /// <summary>
    /// Логика взаимодействия для ProfileEdit.xaml
    /// </summary>
    public partial class ProfileEdit : Window
    {
        bool add = false;
        Bitmap userPhoto;
        Model.User currentUser;
        string photoName;
        bool setPhoto = false;
        bool save = true;
        public ProfileEdit()
        {
            InitializeComponent();
        }
        public ProfileEdit(Model.User currentUser)
        {
            add = false;
            this.currentUser = currentUser;
            InitializeComponent();
            Fio.Text = $"{Classes.User.userSurname} {Classes.User.userName} {Classes.User.userPatronymic}";
            initWindow();
        }
        public ProfileEdit(bool add)
        {
            this.add = add;
            InitializeComponent();
            Fio.Text = $"{Classes.User.userSurname} {Classes.User.userName} {Classes.User.userPatronymic}";
            initWindow2();
            ButtonDelete.Visibility = Visibility.Hidden;
            ButtonDelete.IsEnabled = false;

        }

        /// <summary>
        /// Метод выполняет инициализацию формы
        /// </summary>
        private void initWindow()
        {
            BirthDate.IsEnabled = false;
            try
            {
                District.Text = this.currentUser.District.First().DistrictName;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                //throw;
                return;
            }
            Surname.Text = this.currentUser.UserSurname;
            Name.Text = this.currentUser.UserName;
            Patronymic.Text = this.currentUser.UserPatronymic;
            Role.Text = this.currentUser.Role.RoleName;
            string path = Environment.CurrentDirectory + $@"\images\{this.currentUser.Photo}";
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
            Phone.Text = this.currentUser.Phone;
            Email.Text = this.currentUser.Email;
            BirthDate.SelectedDate = Convert.ToDateTime(this.currentUser.BirthDate);
            Login.Text = this.currentUser.Login;
            Password.Text = this.currentUser.Password;
        }
        /// <summary>
        /// Метод выполняет инициализацию формы
        /// </summary>
        private void initWindow2()
        {
            BirthDate.IsEnabled = true;
            Surname.Text = "";
            Name.Text = "";
            Patronymic.Text = "";
            Role.Text = "Волонтер";
            District.Text = Classes.User.district.DistrictName;
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
            setPhoto = false;
            photoName = "";
            Phone.Text = "";
            Email.Text = "";
            BirthDate.SelectedDate = null;
            Login.Text = "";
            Password.Text = "";
        }

        /// <summary>
        /// Действия по нажатию на кнопку выбора фото
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectPhoto_Click(object sender, RoutedEventArgs e)
        {   
            Bitmap imageBitmap;
            Image image;
            OpenFileDialog selectFileDialog = new OpenFileDialog();
            selectFileDialog.Filter = "PNG files(*.png)|*.png|Image files(*.jpg)|*.jpg";
            if (selectFileDialog.ShowDialog() == true)
            {
                string fileName = selectFileDialog.FileName; ;
                try
                {
                    
                    image = Image.FromFile(fileName);
                    userPhoto = new Bitmap(image);

                    string name = IO.Path.GetFileName(fileName);
                    photoName = name;
                    try
                    {
                        image.Save(Environment.CurrentDirectory + $@"\images\{name}");
                    }
                    catch (Exception ex)
                    {
                        //файл уже записан пропуск действия
                    }
                    image.Dispose();
                    BitmapImage bitmapImage;
                    Bitmap bmp = userPhoto;
                    using (var memory = new IO.MemoryStream())
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
                    setPhoto = true;

                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Неверный формат файла", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (OutOfMemoryException ex)
                {
                    MessageBox.Show("Недостаточно памяти для открытия файла", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неизвестная ошибка", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                setPhoto = false;
                photoName = "";
                return;
            }
        }
        /// <summary>
        /// Действия по нажатию на кнопку удаления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Model.User copyUser = new Model.User();
            copyUser = this.currentUser;
            var res = MessageBox.Show("Данные будут удалены без возможности восстановления.\r\nВы действительно хотите удалить данные о волонтере?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                try
                {   
                    

                    Helper.DB.User.Remove(currentUser);
                    Helper.DB.SaveChanges();
                    MessageBox.Show("Данные успешно удалены.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.currentUser = copyUser;
                    if (copyUser.UserID == Classes.User.userID)
                    {
                        Classes.User.userID = -1;
                    }
                    if (Classes.User.roleID!=2)
                    {
                        Classes.User.userID = -1;
                        Close();
                    }
                    save = true;
                    
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка сохранения данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

        }
        /// <summary>
        /// Действия по нажатию на кнопку сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Model.User copyUser = new Model.User();
            
            string surName;
            string name;
            string patronymic;
            string login="";
            string password;
            DateTime bDate;
            string email;
            string phone;
            if (!add)
            {
                copyUser = currentUser;
                login = copyUser.Login;
            }
            if (Name.Text.Length < 1 || Surname.Text.Length < 1)
            {
                MessageBox.Show("Имя и фамилия не могут быть пустыми", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                name = Name.Text;
                surName = Surname.Text;
            }
            if (Login.Text.Length < 3 || Login.Text.Length > 50) 
            {
                MessageBox.Show("Логин введен неверно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                if(add)
                {
                    if (Helper.DB.User.Where(x => x.Login == Login.Text).ToList().Count > 0)
                    {
                        MessageBox.Show("Такой логин уже занят", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    else
                    {
                        login = Login.Text;
                    }
                }
            }
            if (Password.Text.Length > 50 || Password.Text.Length < 8 || !Password.Text.Any(char.IsLetter) || !Password.Text.Any(char.IsDigit) || !Password.Text.Any(char.IsPunctuation) || !Password.Text.Any(char.IsLower) || !Password.Text.Any(char.IsUpper))
            {
                MessageBox.Show("Пароль слишком простой", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                password = Password.Text;
            }
            patronymic = Patronymic.Text;
            if(!Email.Text.Contains("@")|| !Email.Text.Contains("."))
            {
                MessageBox.Show("Введите электронную почту", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                email = Email.Text;
            }
            if (Phone.Text.Length<12|| Phone.Text.Any(char.IsLetter) || Phone.Text.Any(char.IsLower) || Phone.Text.Any(char.IsUpper))
            {
                MessageBox.Show("Неверный номер телефона", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                phone = Phone.Text;
            }
            if(setPhoto)
            {
                copyUser.Photo = photoName;
            }
            if(add)
            {
                int newID = 1;
                Model.Role newRole = new Model.Role();
                try
                {
                    newRole = Helper.DB.Role.Where(x => x.RoleID == 3).FirstOrDefault();
                    newID = Helper.DB.User.Max(x => x.UserID) + 1;
                }
                catch (Exception ex)
                {
                    newID = 1;
                }
                try
                {
                    if(BirthDate.SelectedDate==null|| BirthDate.SelectedDate > DateTime.Today.AddYears(-16))
                    {
                        MessageBox.Show("Дата рождения введена неверно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    else
                    {
                        bDate = Convert.ToDateTime(BirthDate.SelectedDate);
                    }
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Дата рождения введена неверно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                copyUser = new Model.User();
                copyUser.BirthDate = bDate;
                copyUser.District.Add(Classes.User.district);
                copyUser.UserSurname = surName;
                copyUser.UserName = name;
                copyUser.UserPatronymic = patronymic;
                copyUser.Login = login;
                copyUser.Password = password;
                copyUser.Email = email;
                copyUser.Phone = phone;
                copyUser.Photo = photoName;
                copyUser.UserID = newID;
                copyUser.RoleID = 3;
                copyUser.Role = newRole;
                try
                {
                    Helper.DB.User.Add(copyUser);
                    Helper.DB.SaveChanges();
                    save = true;
                    MessageBox.Show($"Зарегистрировн новый волонтер\r\nИдентификатор нового волонтера: {newID}", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка сохранения данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            else
            {
                copyUser.UserSurname = surName;
                copyUser.UserName = name;
                copyUser.UserPatronymic = patronymic;
                copyUser.Login = login;
                copyUser.Password = password;
                copyUser.Email = email;
                copyUser.Phone = phone;
                copyUser.Photo = photoName;
                try
                {

                    Helper.DB.SaveChanges();
                    save = true;
                    MessageBox.Show("Данные успешно сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.currentUser = copyUser;
                    userPhoto = null;
                    initWindow();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка сохранения данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }            
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

        
        /// <summary>
        /// Действия при изменения текста в полях для ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Surname_TextChanged(object sender, TextChangedEventArgs e)
        {
            save = false;
        }

        private void BirthDate_CalendarClosed(object sender, RoutedEventArgs e)
        {
            save = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(Classes.User.userID>0){
                if (save)
                {
                    MessageBox.Show("Изменения сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    var res = MessageBox.Show("Изменения не сохранены.\r\nЗакрыть без сохранения?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (res == MessageBoxResult.No)
                    {
                        e.Cancel = true;

                    }
                    else
                    {
                        e.Cancel = false;
                    }
                }
            }
            else
            {

            }
            
        }
    }
}
