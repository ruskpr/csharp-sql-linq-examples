using ClassLibrary;
using System.Windows.Controls;

namespace LinqExamples.Pages.Orders.DataTable
{
    /// <summary>
    /// Interaction logic for GetOrdersByCustomerID.xaml
    /// </summary>
    public partial class GetOrdersByCustomerID : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetOrdersByCustomerID()
        {
            InitializeComponent();

            // show full orders table 
            dgData.ItemsSource = sqliteLayer.GetOrdersTable().DefaultView;
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Data.DataTable? orders = bl.GetOrdersByCustomerID(tbInput.Text);

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
