using ClassLibrary;
using System.Windows.Controls;

namespace LinqExamples.Pages.Orders.DataTable
{
    /// <summary>
    /// Interaction logic for GetOrdersByEmployeeID.xaml
    /// </summary>
    public partial class GetOrdersByEmployeeID : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetOrdersByEmployeeID()
        {
            InitializeComponent();

            // show full orders table 
            dgData.ItemsSource = sqliteLayer.GetOrdersTable().DefaultView;
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            int employeeId;
            bool isValidInteger = int.TryParse(tbInput.Text, out employeeId);

            if (isValidInteger)
            {
                System.Data.DataTable? orders = bl.GetOrdersByEmployeeID(employeeId);

                if (orders != null)
                {
                    dgData.ItemsSource = orders.DefaultView;
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
