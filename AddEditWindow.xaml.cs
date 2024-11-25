using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace avtoServ
{
    public partial class AddEditWindow : Window
    {
        private STObase sSTObase = new STObase();
        private Avto numberAvto = new Avto();
        private Clients client = new Clients();

        public AddEditWindow()
        {
            InitializeComponent();
            DataContext = sSTObase;
            ComboStatus.ItemsSource = STOEntities.GetContext().RequestStatus.ToList();
            BrandAvtoCombo.ItemsSource = STOEntities.GetContext().Avto.ToList();
            FaultTypesCombo.ItemsSource = STOEntities.GetContext().FaultTypes.ToList();
            DetailCombo.ItemsSource = STOEntities.GetContext().Detail.ToList();
        }

        private void BthSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (sSTObase.application_number == null)
            {
                error.AppendLine("Введите номер заявки!");
            }

            else if (!int.TryParse(sSTObase.application_number.ToString(), out int applicationNumber) || applicationNumber <= 0)
            {
                error.AppendLine("Номер заявки должен иметь положительное и не отрицательное значение!");
            }

            else if (STOEntities.GetContext().STObase.Any(row => row.application_number == sSTObase.application_number))
            {
                error.AppendLine("Номер заявки уже существует!");
            }

            if (sSTObase.request_date == null || sSTObase.request_date == DateTime.MinValue)
            {
                error.AppendLine("Укажите дату!");
            }

            if (string.IsNullOrWhiteSpace(ClientsTextBox.Text))
            {
                error.AppendLine("Укажите клиента!");
            }

            if (BrandAvtoCombo.SelectedItem != null && BrandAvtoCombo.SelectedItem is Avto selectedBrandAvto)
            {
                sSTObase.ID_Avto = selectedBrandAvto.ID_Avto;
            }
            else error.AppendLine("Укажите марку автомобиля!");

            //if (string.IsNullOrWhiteSpace(NumberAvtoTextBox.Text))
            //{
            //    error.AppendLine("Укажите номер автомобиля!");
            //}

            if (FaultTypesCombo.SelectedItem != null && FaultTypesCombo.SelectedItem is FaultTypes selectedFaultTypes)
            {
                sSTObase.fault_type_id = selectedFaultTypes.fault_type_id;
            }
            else error.AppendLine("Укажите тип неисправности!");

            if (DetailCombo.SelectedItem != null && DetailCombo.SelectedItem is Detail selectedDetailCombo)
            {
                sSTObase.ID_Detail = selectedDetailCombo.ID_Detail;
            }
            else error.AppendLine("Укажите необходимую деталь!");

            if (ComboStatus.SelectedItem != null && ComboStatus.SelectedItem is RequestStatus selectedStatus)
            {
                sSTObase.ID_RequestStatus = selectedStatus.ID_RequestStatus;
            }
            else error.AppendLine("Выберите статус!");
  
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                var context = STOEntities.GetContext();      

               client.Client_name = ClientsTextBox.Text;
               //numberAvto.Number = NumberAvtoTextBox.Text;

               context.Clients.Add(client);
              //context.Avto.Add(numberAvto);
               context.SaveChanges();

                var clientId = client.ID_Clients;
                //var numberAvtoId = numberAvto.ID_Avto;

               sSTObase.ID_Clients = clientId;
               //sSTObase.ID_Avto = numberAvtoId;

                context.STObase.Add(sSTObase);
                context.SaveChanges();
                MessageBox.Show("Информация сохранена");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
