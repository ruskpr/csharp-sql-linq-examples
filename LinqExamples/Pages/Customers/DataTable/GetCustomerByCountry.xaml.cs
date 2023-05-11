using ClassLibrary;
using System.Windows.Controls;

namespace LinqExamples.Pages.Customers.DataTable
{
    /// <summary>
    /// Interaction logic for GetCustomerByCountry.xaml
    /// </summary>
    public partial class GetCustomerByCountry : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetCustomerByCountry()
        {
            InitializeComponent();

            // show full customers table 
            dgData.ItemsSource = sqliteLayer.GetCustomersTable().DefaultView;
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Data.DataTable? customers = bl.GetCustomerByCountry(tbInput.Text);

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
