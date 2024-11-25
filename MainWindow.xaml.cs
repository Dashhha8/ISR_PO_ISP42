using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace avtoServ
{
    public partial class MainWindow : Window
    {
        private STObase sSTObase = new STObase();
        public MainWindow()
        {
            InitializeComponent();
            STOAvto.ItemsSource = STOEntities.GetContext().STObase.ToList();
            ComboStatus.ItemsSource = STOEntities.GetContext().RequestStatus.ToList();
            Box.Text = STOEntities.GetContext().STObase.Count(r => r.ID_RequestStatus == 2).ToString();
            Vis();
        }


        private void STOAvto_Loaded(object sender, RoutedEventArgs e)
        {
            if (STOAvto.Columns.Any())
            {
                STOAvto.Columns.RemoveAt(STOAvto.Columns.Count - 1);
            }
        }

        private void Vis()
        {
            switch (AuthorizationWindow.authorizationRole)
            {
                case "1": //Админ
                    break;
                case "2": //Модер
                    BtnDelet.Visibility = Visibility.Collapsed;
                    break;
                case "3": //Юзер
                    BtnDelet.Visibility = Visibility.Collapsed;
                    STOAvto.Loaded += STOAvto_Loaded;
                    break;
                default:
                    return;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e) //Редактировать
        {
            RefreshWindow addEditWindow = new RefreshWindow((sender as Button).DataContext as STObase);
            addEditWindow.ShowDialog();
            STOAvto.ItemsSource = STOEntities.GetContext().STObase.ToList();
            Box.Text = STOEntities.GetContext().STObase.Count(r => r.ID_RequestStatus == 2).ToString();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) //Добавить
        {
            AddEditWindow addEditWindow = new AddEditWindow();
            addEditWindow.ShowDialog();
            STOAvto.ItemsSource = STOEntities.GetContext().STObase.ToList();
            Box.Text = STOEntities.GetContext().STObase.Count(r => r.ID_RequestStatus == 2).ToString();
        }

        private void BtnDelet_Click(object sender, RoutedEventArgs e)//Удалить
        {
            var servisForRemoving = STOAvto.SelectedItems.Cast<STObase>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {servisForRemoving.Count()} элементы?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    STOEntities context = STOEntities.GetContext();

                    context.STObase.RemoveRange(servisForRemoving);

                    foreach (var requestStatus in servisForRemoving)
                    {
                        var DetailToRemove = context.Detail.Where(l => l.ID_Detail == sSTObase.request_id);
                        context.Detail.RemoveRange(DetailToRemove);

                        var clientToRemove = context.Clients.Where(c => c.ID_Clients == sSTObase.request_id);
                        context.Clients.RemoveRange(clientToRemove);

                        var FaultTypesToRemove = context.FaultTypes.Where(f => f.fault_type_id == sSTObase.request_id);
                        context.FaultTypes.RemoveRange(FaultTypesToRemove);
                    }
                    context.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    STOAvto.ItemsSource = context.STObase.ToList();
                    Box.Text = STOEntities.GetContext().STObase.Count(r => r.ID_RequestStatus == 2).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnUp_Click(object sender, RoutedEventArgs e)//Обновить
        {
            STOAvto.ItemsSource = STOEntities.GetContext().STObase.ToList();
        }

        private void BtnOut_Click(object sender, RoutedEventArgs e)//Применить
        {
            if (ComboStatus.SelectedItem != null && ComboStatus.SelectedItem is RequestStatus selectedStatus)
            {
                int selectedStatusId = selectedStatus.ID_RequestStatus;
                STOAvto.ItemsSource = STOEntities.GetContext().STObase.Where(r => r.ID_RequestStatus == selectedStatusId).ToList();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e) //текстБокс для поиска нужных данных
        {
            string searchText = SearchBox.Text;
            STOAvto.ItemsSource = STOEntities.GetContext().STObase.Where(r =>
                    r.application_number.ToString().Contains(searchText) ||
                    r.FaultTypes.fault_type_name.Contains(searchText) ||
                    r.Detail.Name_Detail.Contains(searchText) ||
                    r.Clients.Client_name.Contains(searchText) ||
                    r.RequestStatus.Status_name.Contains(searchText) ||
                    r.Avto.Brand.Contains(searchText) ||
                    r.Avto.Number.Contains(searchText))
                .ToList();
        }

        private void BtnAuthorization_Click(object sender, RoutedEventArgs e) //Вернуться
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }
    } 
}