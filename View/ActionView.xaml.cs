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
using Model = GiveGood.Classes.Model;
using Helper = GiveGood.Classes.DBHelper;

namespace GiveGood.View
{
    /// <summary>
    /// Логика взаимодействия для ActionView.xaml
    /// </summary>
    public partial class ActionView : Window
    {

        Model.User user;
        Classes.Model.Action currentAction;
        bool inAction = false;
        public ActionView()
        {
            InitializeComponent();

        }
        public ActionView(Classes.Model.Action currentAction)
        {
            user = Helper.DB.User.Where(x => x.UserID == Classes.User.userID).FirstOrDefault();
            this.currentAction = currentAction;
            InitializeComponent();
            initWindow();

        }
        /// <summary>
        /// Метод выполняет инициализацию формы
        /// </summary>
        protected void initWindow()
        {
            Join.Content = "Присоединиться";

            if (this.currentAction.User1.Contains(user))
            {
                inAction = true;
            }
            ActionDistrict.Text = this.currentAction.District.First().DistrictName;
            ActionID.Text = this.currentAction.ActionID.ToString();
            ActionName.Text = this.currentAction.ActionName;
            ActionDescription.Text = this.currentAction.ActionDescription;
            ActionMaxPart.Text = this.currentAction.ActionMaxParticipants.ToString();
            ActionPart.Text = this.currentAction.User1.Count.ToString();
            ActionRegDate.Text = Convert.ToDateTime(this.currentAction.ActionRegisterDate).ToShortDateString();
            ActionStartDate.Text = Convert.ToDateTime(this.currentAction.ActionStartDate).ToShortDateString();
            ActionDistrict.Text = this.currentAction.District.First().DistrictName;
            ActionType.Text = this.currentAction.ActionType.ActionTypeName;
            ActionStatus.Text = this.currentAction.ActionStatus.ActionStatusName;
            if (this.currentAction.ActionFinishDate.ToString() != "")
            {
                ActionEndDate.Text = Convert.ToDateTime(this.currentAction.ActionFinishDate).ToShortDateString();
                ActionEndDate.Visibility = Visibility.Visible;
            }
            else
            {
                ActionEndDate.Text = null;
                ActionEndDate.Visibility = Visibility.Hidden;
            }
            Updatelist();
            Fio.Text = $"{Classes.User.userSurname} {Classes.User.userName} {Classes.User.userPatronymic}";
            if(user.RoleID==3)
            {
                if (this.currentAction.ActionStatusID == 1 && this.currentAction.District.First() == Classes.User.district && this.currentAction.User1.Count < this.currentAction.ActionMaxParticipants)
                {
                    Join.IsEnabled = true;
                    Join.Visibility = Visibility.Visible;
                }
                else
                {
                    Join.IsEnabled = false;
                    Join.Visibility = Visibility.Hidden;
                }
                if (inAction)
                {
                    Join.Content = "Покинуть акцию";
                }
            }
            else
            {
                Join.IsEnabled = false;
                Join.Visibility = Visibility.Hidden;
            }
            
        }
        /// <summary>
        /// Метод выполняет обновление списка акций, выводимых на форму с учетом установленных параметров сортировки
        /// </summary>
        private void Updatelist()
        {
            try
            {
                List<Model.User> participations = this.currentAction.User1.ToList();
                if(participations.Count>0)
                {
                    ActionList.ItemsSource = participations;
                    ListBorder.Visibility = Visibility.Visible;
                }
                else
                {
                    ListBorder.Visibility = Visibility.Hidden;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
        /// Действия по нажатию на кнопку присоединения к акции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Join_Click(object sender, RoutedEventArgs e)
        {
            if (inAction)
            {
                var res = MessageBox.Show("Хотите покинуть акцию?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        this.currentAction.User1.Remove(user);
                        Helper.DB.SaveChanges();
                        MessageBox.Show("Вы поуинули акцию", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        initWindow();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка покидания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            }
            else
            {
                try
                {
                    List<Model.User> tempUsers = this.currentAction.User1.ToList();
                    tempUsers.Add(user);
                    this.currentAction.User1 = tempUsers;
                    Helper.DB.SaveChanges();
                    MessageBox.Show("Вы присоединились к акции", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    initWindow();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка присоединения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                
            }
        }
    }
}
