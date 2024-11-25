using System.Linq;
using System.Windows;


namespace avtoServ
{
    public partial class RefreshWindow : Window
    {
        private STObase _currentRequest;
        public RefreshWindow(STObase sSTObase)
        {
            InitializeComponent();
            _currentRequest = sSTObase;

            StatusComboBox.ItemsSource = STOEntities.GetContext().RequestStatus.ToList();
            AvtComboBox.ItemsSource = STOEntities.GetContext().Avto.ToList();
            FaultTypeComboBox.ItemsSource = STOEntities.GetContext().FaultTypes.ToList();

            // Презагрузка данных
            DescriptionTextBox.Text = sSTObase.Avto.Number;
            CliTextBox.Text = sSTObase.Clients.Client_name;
            StatusComboBox.SelectedItem = sSTObase.RequestStatus.Status_name;
            AvtComboBox.SelectedItem = sSTObase.Avto.Brand;
            FaultTypeComboBox.SelectedItem = sSTObase.FaultTypes;
        } 

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Здесь код для обновления данных в базе
            var context = STOEntities.GetContext();
            _currentRequest.Avto.Number = DescriptionTextBox.Text;
            _currentRequest.ID_RequestStatus = ((RequestStatus)StatusComboBox.SelectedItem).ID_RequestStatus;
            _currentRequest.ID_Avto = ((Avto)AvtComboBox.SelectedItem).ID_Avto;
            _currentRequest.fault_type_id = ((FaultTypes)FaultTypeComboBox.SelectedItem).fault_type_id;
            _currentRequest.Clients.Client_name = CliTextBox.Text;
            context.SaveChanges();
            MessageBox.Show("Данные заявки обновлены");
            this.Close();
        }
    }
}