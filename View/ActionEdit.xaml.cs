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
    /// Логика взаимодействия для ActionEdit.xaml
    /// </summary>
    public partial class ActionEdit : Window
    {
        bool save = true;
        int maxID=-1;
        Classes.Model.Action currentAction;
        Classes.Model.Action copyAction;
        public ActionEdit()
        {
            InitializeComponent();
        }
        public ActionEdit(Classes.Model.Action currentAction)
        {
            this.currentAction = currentAction;
            InitializeComponent();
            initWindow();
            Fio.Text = $"{Classes.User.userSurname} {Classes.User.userName} {Classes.User.userPatronymic}";

        }
        public ActionEdit(int maxID)
        {
            this.maxID = maxID;
            InitializeComponent();
            initWindow2(this.maxID);
            Fio.Text = $"{Classes.User.userSurname} {Classes.User.userName} {Classes.User.userPatronymic}";
            ButtonDelete.IsEnabled = false;
            ButtonDelete.Visibility = Visibility.Hidden;

        }
        /// <summary>
        /// Метод выполняет инициализацию формы
        /// </summary>
        protected void initWindow()
        {
            List<string> values = new List<string>();
            List<Model.ActionType> actionTypes = Helper.DB.ActionType.ToList();
            foreach (Model.ActionType item in actionTypes)
            {
                string s = item.ActionTypeName;
                values.Add(s);
            }
            ActionType.ItemsSource = values;
            List<string> values1 = new List<string>();
            List<Model.ActionStatus> actionStatuses = Helper.DB.ActionStatus.ToList();
            foreach (Model.ActionStatus item in actionStatuses)
            {
                string s = item.ActionStatusName;
                values1.Add(s);
            }
            ActionStatus.ItemsSource = values1;

            List<string> values2 = new List<string>();
            List<Model.District> districts = Helper.DB.District.ToList();
            foreach (Model.District item in districts)
            {
                string s = item.DistrictName;
                values2.Add(s);
            }
            

            for (int i = 0; i < actionTypes.Count; i++)
            {
                if (this.currentAction.ActionType.ActionTypeID == actionTypes.ElementAt(i).ActionTypeID)
                {
                    ActionType.SelectedIndex = i;
                }
                else
                {
                    continue;
                }
            }
            for (int i = 0; i < actionStatuses.Count; i++)
            {
                if (this.currentAction.ActionStatus.ActionStatusID == actionStatuses.ElementAt(i).ActionStatusID)
                {
                    ActionStatus.SelectedIndex = i;
                }
                else
                {
                    continue;
                }
            }
            ActionDistrict.Text = this.currentAction.District.First().DistrictName;
            ActionID.Text = this.currentAction.ActionID.ToString();
            ActionName.Text = this.currentAction.ActionName;
            ActionDescription.Text = this.currentAction.ActionDescription;
            ActionMaxPart.Text = this.currentAction.ActionMaxParticipants.ToString();
            ActionRegDate.SelectedDate = Convert.ToDateTime(this.currentAction.ActionRegisterDate);
            ActionStartDate.SelectedDate = Convert.ToDateTime(this.currentAction.ActionStartDate);
            if (this.currentAction.ActionFinishDate.ToString() != "")
            {
                IsEndDate.IsChecked = true;
                ActionEndDate.SelectedDate = this.currentAction.ActionFinishDate;
                ActionEndDate.Visibility = Visibility.Visible;
            }
            else
            {
                IsEndDate.IsChecked = false;
                ActionEndDate.SelectedDate = null;
                ActionEndDate.Visibility = Visibility.Hidden;
            }
        }
        /// <summary>
        /// Метод выполняет инициализацию формы
        /// </summary>
        protected void initWindow2(int maxID)
        {
            List<string> values = new List<string>();
            List<Model.ActionType> actionTypes = Helper.DB.ActionType.ToList();
            foreach (Model.ActionType item in actionTypes)
            {
                string s = item.ActionTypeName;
                values.Add(s);
            }
            ActionType.ItemsSource = values;
            List<string> values1 = new List<string>();
            List<Model.ActionStatus> actionStatuses = Helper.DB.ActionStatus.ToList();
            foreach (Model.ActionStatus item in actionStatuses)
            {
                string s = item.ActionStatusName;
                values1.Add(s);
            }
            ActionStatus.ItemsSource = values1;
            ActionType.SelectedIndex = 0;
            for (int i = 0; i < actionStatuses.Count; i++)
            {
                if (actionStatuses.ElementAt(i).ActionStatusID == 2)
                {
                    ActionStatus.SelectedIndex = i;
                }
                else
                {
                    continue;
                }
            }
            ActionDistrict.Text = Classes.User.district.DistrictName;
            ActionID.Text = maxID.ToString();
            ActionName.Text = "";
            ActionDescription.Text = "";
            ActionMaxPart.Text = "";
            ActionRegDate.SelectedDate = DateTime.Today;
            ActionStartDate.SelectedDate = DateTime.Today.AddDays(1);
            IsEndDate.IsChecked = true;
            ActionEndDate.SelectedDate = DateTime.Today.AddDays(3);
            ActionEndDate.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Действие по нажатию на флажок применения даты окончания акции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsEndDate_Checked(object sender, RoutedEventArgs e)
        {
            if(IsEndDate.IsChecked.Value)
            {
                ActionEndDate.IsEnabled = true;
                ActionEndDate.Visibility = Visibility.Visible;
            }
            else
            {
                ActionEndDate.IsEnabled = false;
                ActionEndDate.Visibility = Visibility.Hidden;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
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
        /// Действия при закрытии формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (save)
            {
                MessageBox.Show("Изменения сохранены","Информация",MessageBoxButton.OK,MessageBoxImage.Information);
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

        /// <summary>
        /// Действия по нажатию на кнопку сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            int maxPart;
            int statusID;
            int typeID;
            string name;
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            if(IsEndDate.IsChecked.Value)
            {
                try
                {
                    startDate = ActionStartDate.SelectedDate.Value;
                }
                catch (Exception)
                {
                    MessageBox.Show("Дата начала акции введена неверно", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                try
                {
                    endDate = ActionEndDate.SelectedDate.Value;
                }
                catch (Exception)
                {
                    MessageBox.Show("Дата окончания акции введена неверно", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (endDate < startDate)
                {
                    MessageBox.Show("Дата окончания акции должна быть меньше даты начала акции", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            else
            {
                try
                {
                    startDate = ActionStartDate.SelectedDate.Value;
                }
                catch (Exception)
                {
                    MessageBox.Show("Дата начала акции введена неверно", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            try
            {
                maxPart = Convert.ToInt32(ActionMaxPart.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Максимальное количество участников введено неверно", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(maxPart<1)
            {
                MessageBox.Show("Максимальное количество участников не может быть меньше 1", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            name = ActionName.Text;
            if(name.Length>100)
            {
                MessageBox.Show("Наименование акции слишком длинное", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if(maxID>0){
                    Model.Action newAction=new Model.Action();
                    try
                    {
                        newAction.ActionID = maxID;
                        newAction.ActionName = name;
                        newAction.ActionDescription = ActionDescription.Text;
                        newAction.ActionMaxParticipants = maxPart;
                        newAction.ActionRegisterDate = DateTime.Today;
                        newAction.ActionStartDate = startDate;
                        if (IsEndDate.IsChecked.Value)
                        {
                            newAction.ActionFinishDate = endDate;
                        }
                        statusID = ActionStatus.SelectedIndex + 1;
                        typeID = ActionType.SelectedIndex + 1;
                        Model.ActionType tempTypes = Helper.DB.ActionType.Where(x => x.ActionTypeID == typeID).FirstOrDefault();
                        newAction.ActionType = tempTypes;
                        Model.ActionStatus tempStatuses = Helper.DB.ActionStatus.Where(x => x.ActionStatusID == statusID).FirstOrDefault();
                        newAction.ActionStatus = tempStatuses;
                        Model.District tempDistricts = Helper.DB.District.Where(x => x.DistrictName == ActionDistrict.Text).FirstOrDefault();
                        newAction.District.Add(tempDistricts);
                        Model.User tempUser = Helper.DB.User.Where(x => x.UserID == Classes.User.userID).FirstOrDefault();
                        newAction.User.Add(tempUser);
                        Helper.DB.Action.Add(newAction);
                        Helper.DB.SaveChanges();
                        save = true;
                        MessageBox.Show("Данные успешно сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка сохранения данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else{
                    try
                    {
                        copyAction = this.currentAction;
                        copyAction.ActionName = name;
                        copyAction.ActionDescription = ActionDescription.Text;
                        copyAction.ActionMaxParticipants = maxPart;
                        copyAction.ActionStartDate = startDate;
                        if (IsEndDate.IsChecked.Value)
                        {
                            copyAction.ActionFinishDate = endDate;
                        }
                        statusID = ActionStatus.SelectedIndex + 1;
                        typeID = ActionType.SelectedIndex + 1;
                        Model.ActionType tempTypes = Helper.DB.ActionType.Where(x => x.ActionTypeID == typeID).FirstOrDefault();
                        copyAction.ActionType = tempTypes;
                        Model.ActionStatus tempStatuses = Helper.DB.ActionStatus.Where(x => x.ActionStatusID == statusID).FirstOrDefault();
                        copyAction.ActionStatus = tempStatuses;
                        Helper.DB.SaveChanges();
                        save = true;
                        MessageBox.Show("Данные успешно сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.currentAction = copyAction;
                        initWindow();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка сохранения данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                
            }
        }
        /// <summary>
        /// Действия при вводе текста в поле наименования и поля описания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionName_TextChanged(object sender, TextChangedEventArgs e)
        {
            save = false;
        }
        /// <summary>
        /// Действия по изменению выбранного значения выпадающих списков типа, статуса и района
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            save = false;
        }
        /// <summary>
        /// Действия по нажатию на кнопку удаления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            this.copyAction = this.currentAction;
            if (this.copyAction.ActionStatus.ActionStatusID == 3)
            {
                var res = MessageBox.Show("Данные будут удалены без возможности восстановления.\r\nВы действительно хотите удалить данные об акции?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {

                        Helper.DB.Action.Remove(currentAction);
                        Helper.DB.SaveChanges();
                        MessageBox.Show("Данные успешно удалены.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.currentAction = copyAction;
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
            else
            {
                MessageBox.Show($"Удалять данную акцию нельза, так как статус не равен статусу {"Завершена"}", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
