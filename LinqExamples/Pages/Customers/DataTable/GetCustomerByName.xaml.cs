using ClassLibrary;
using System.Windows.Controls;

namespace LinqExamples.Pages.Customers.DataTable
{
    /// <summary>
    /// Interaction logic for GetCustomerByName.xaml
    /// </summary>
    public partial class GetCustomerByName : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetCustomerByName()
        {
            InitializeComponent();

            // show full customers table 
            dgData.ItemsSource = sqliteLayer.GetCustomersTable().DefaultView;
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Data.DataTable? customers = bl.GetCustomerByName(tbInput.Text);

            if (customers != null)
            {
                dgData.ItemsSource = customers.DefaultView;
                lbErrorMsg.Text = "";
            }
            else
            {
                lbErrorMsg.Text = "No Records Found";
            }
        }
    }
}
