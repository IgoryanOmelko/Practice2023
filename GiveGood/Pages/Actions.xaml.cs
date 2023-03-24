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

namespace GiveGood.Pages
{
    /// <summary>
    /// Логика взаимодействия для Actions.xaml
    /// </summary>
    public partial class Actions : Page
    {
        int selectedDistrict;
        int selectedType;
        int selectedStatus;
        List<Model.Action> actions;
        List<ActionEx> actionsEx;
        int beforeCount;
        public Actions()
        {
            InitializeComponent();
            beforeCount = Helper.DB.Action.ToList().Count;
            List<string> values = new List<string>();
            if(Classes.User.roleID==2)
            {
                AddAction.IsEnabled = false;
                AddAction.Visibility = Visibility.Hidden;
            }

            List<Model.ActionType> actionTypes = Helper.DB.ActionType.ToList();
            foreach (Model.ActionType item in actionTypes)
            {
                string s = item.ActionTypeName;
                values.Add(s);
            }
            values.Insert(0, "Все типы");
            TypeFilt.ItemsSource = values;
            List<string> values1 = new List<string>();
            List<Model.ActionStatus> actionStatuses= Helper.DB.ActionStatus.ToList();
            foreach (Model.ActionStatus item in actionStatuses)
            {
                string s = item.ActionStatusName;
                values1.Add(s);
            }
            values1.Insert(0, "Все статусы");
            StatusFilt.ItemsSource = values1;
            
            List<string> values2 = new List<string>();
            List<Model.District> districts = Helper.DB.District.ToList();
            foreach (Model.District item in districts)
            {
                string s = item.DistrictName;
                values2.Add(s);
            }
            values2.Insert(0, "Все районы");
            DistrictFilt.ItemsSource = values2;
            TypeFilt.SelectedIndex = 0;
            StatusFilt.SelectedIndex = 0;
            DistrictFilt.SelectedIndex = 0;
            selectedDistrict = DistrictFilt.SelectedIndex;
            selectedType = TypeFilt.SelectedIndex;
            selectedStatus = StatusFilt.SelectedIndex;
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
        private List<Model.Action> GetActions()
        {
            List<Model.Action> result = new List<Model.Action>();
            try
            {
                result = Helper.DB.Action.OrderBy(x=>x.ActionName).ToList();
            }
            catch (Exception)
            {
                result = null;
            }    
            return result;
        }
        /// <summary>
        /// Метод выполняет получение списка акций, тип которых соответствует входному значению
        /// </summary>
        /// <param name="value">Значение параметра отбора (Идентификатор)</param>
        private void TypeFilter(int value)
        {
            if(value>0){
                try
                {
                    actions = actions.Where(x => x.ActionTypeID == value).ToList();
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
        /// Метод выполняет получение списка акций, статус которых соответствует входному значению
        /// </summary>
        /// <param name="value">Значение параметра отбора (Идентификатор)</param>
        private void StatusFilter(int value)
        {
            if(value>0){
                try
                {
                    actions = actions.Where(x => x.ActionStatusID == value).ToList();
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
        /// Метод выполняет получение списка акций, район которых соответствует входному значению
        /// </summary>
        /// <param name="value">Значение параметра отбора (Идентификатор)</param>
        private void DistrictFilter(int value)
        {   
            if(value>0){
                try
                {
                    actions = actions.Where(x => x.District.First().DistrictID == value).ToList();
                }
                catch (Exception)
                {
                    return;
                }
            }
            else{
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
                actions = actions.Where(x => x.ActionName.Contains(value) || x.ActionDescription.Contains(value)||x.District.First().DistrictName.Contains(value)).ToList();
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
        private void OwnedFilter(bool value){
            try
            {
                if(value)
                {
                    actions = actions.Where(x => x.User.First().UserID == Classes.User.userID).ToList();
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
                beforeCount = Helper.DB.Action.ToList().Count;
                actions = GetActions();
                SearchFilter(Search.Text);
                OwnedFilter(isOwned.IsChecked.Value);
                TypeFilter(selectedType);
                StatusFilter(selectedStatus);
                DistrictFilter(selectedDistrict);
                convertToEx();
                ActionList.ItemsSource = actionsEx;
                int displayed = actions.Count;
                Found.Text = $"{displayed} из {beforeCount}";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Метод выполняет конвертацию списка акций, полученного из базы данных, в список, отображаемых на форме
        /// </summary>
        private void convertToEx(){
            actionsEx = new List<ActionEx>();
            foreach (Model.Action item in actions)
            {
                ActionEx ae = new ActionEx();
                //ae.DstName = item.District.First().DistrictName;
                //ae.ActDesc = item.ActionDescription;
                //ae.ActName = item.ActionName;
                ae.ActionName = item.ActionName;
                ae.ActionDescription = item.ActionDescription;
                ae.DstName = item.District.First().DistrictName;
                actionsEx.Add(ae);
            }
        }
        /// <summary>
        /// Действия по нажатию на кнопку редактирования акции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if(Classes.User.roleID==3)
            {
                MessageBox.Show("Действие недоступно","Предупреждение",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }
            Model.Action currentAction;
            int selectedIndex=-1;
            try
            {
                selectedIndex = ActionList.Items.IndexOf((Object)(sender as Button).DataContext);
                int currentActionID = actions.ElementAt(selectedIndex).ActionID;
                currentAction = actions.ElementAt(selectedIndex);
                View.ActionEdit actionEditWindow = new View.ActionEdit(currentAction);
                Window menu = Window.GetWindow(this);
                menu.Hide();
                actionEditWindow.ShowDialog();
                Updatelist();
                menu.Show();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        /// <summary>
        /// Действия по нажатию на кнопку просмотра акции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonView_Click(object sender, RoutedEventArgs e)
        {
            Model.Action currentAction;
            int selectedIndex = -1;
            try
            {
                selectedIndex = ActionList.Items.IndexOf((Object)(sender as Button).DataContext);
                int currentActionID = actions.ElementAt(selectedIndex).ActionID;
                currentAction = actions.ElementAt(selectedIndex);
                View.ActionView actionViewWindow = new View.ActionView(currentAction);
                Window menu = Window.GetWindow(this);
                menu.Hide();
                actionViewWindow.ShowDialog();
                Updatelist();
                menu.Show();
            }
            catch (Exception ex)
            {
                return;
            }
            //MessageBox.Show(currentAction.ActionName);
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
        /// Действия по нажатию на флажок соответсвия организатора акции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isOwned_Checked(object sender, RoutedEventArgs e)
        {
            Updatelist();
        }
        /// <summary>
        /// Действия при изменении выбранного значения выпадающего списка сортировки по типу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedType = TypeFilt.SelectedIndex;
            Updatelist();
        }
        /// <summary>
        /// Действия при изменении выбранного значения выпадающего списка сортировки по статусу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedStatus = StatusFilt.SelectedIndex;
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
        private void AddAction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int maxID = 1;
                try
                {
                    maxID = Helper.DB.Action.Max(x => x.ActionID)+1;
                }
                catch (Exception)
                {

                    maxID = 1;
                }
                

                View.ActionEdit actionEditWindow = new View.ActionEdit(maxID);
                Window menu = Window.GetWindow(this);
                menu.Hide();
                actionEditWindow.ShowDialog();
                Updatelist();
                menu.Show();
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
    partial class ActionEx : Model.Action
    {
        string dstName;
        public string actName;
        public string actDesc;
        public string DstName
        {
            get { return dstName; }
            set { dstName = value; }
        }
        public string ActName
        {
            get { return actName; }
            set { actName = value; }
        }
        public string ActDesc
        {
            get { return actDesc; }
            set { actDesc = value; }
        }
    }
}
