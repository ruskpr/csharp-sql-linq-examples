using ClassLibrary;
using System.Windows.Controls;

namespace LinqExamples.Pages.Employees.DataTable
{
    /// <summary>
    /// Interaction logic for GetEmployeeIDFromOrderID.xaml
    /// </summary>
    public partial class GetEmployeeIDFromOrderID : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetEmployeeIDFromOrderID()
        {
            InitializeComponent();

            dgData.ItemsSource = sqliteLayer.GetEmployeesTable().DefaultView;
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            int orderId;
            bool validDecimalNumber = int.TryParse(tbInput.Text, out orderId);

            if (validDecimalNumber)
            {
                System.Data.DataTable employees = bl.GetEmployeeIDFromOrderID(orderId);

                if (employees != null)
                {
                    dgData.ItemsSource = employees.DefaultView;
                    lbErrorMsg.Text = "";
                }
                else
                {
                    lbErrorMsg.Text = "No Records Found";
                }
            }
        }
    }
}
