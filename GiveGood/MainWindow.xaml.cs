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
using GiveGood.View;
using Model = GiveGood.Classes.Model;
using Helper = GiveGood.Classes.DBHelper;

namespace GiveGood
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Helper.DB = new Model.GiveGoodEntities();
            InitializeComponent();
        }
        /// <summary>
        /// Метод выполняет действия по нажатию на кнопку регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text;
            string password = TextBoxPassword.Text;
            if(login.Length==0||password.Length==0){
                MessageBox.Show("Неверный логин или пароль!");
            }else{
                List<Model.User> Users = new List<Model.User>();
                try
                {
                    Users = Helper.DB.User.Where(x => x.Login == login && x.Password == password).ToList();
                    Classes.User.userName = Users.First().UserName;
                    Classes.User.userSurname = Users.First().UserSurname;
                    Classes.User.userPatronymic = Users.First().UserPatronymic;
                    Classes.User.roleName = Users.First().Role.RoleName;
                    Classes.User.userID = Users.First().UserID;
                    Classes.User.district = Users.First().District.First();
                    Classes.User.roleID = Users.First().RoleID;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Пользователь не найден","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                    //throw;
                    return;
                }
                if(Users.Count>0){
                    MessageBox.Show($"Вы вошли как {Classes.User.roleName}\r\n{Classes.User.userSurname} {Classes.User.userName} {Classes.User.userPatronymic}", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else{
                    MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                View.Menu menuWindow = new View.Menu();
                this.Hide();
                menuWindow.Show();
                
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var res = MessageBox.Show("Вы действительно хотите выйти?", "Выход",MessageBoxButton.YesNo,MessageBoxImage.Question);

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
}
