using ClassLibrary.Sqlite;
using ClassLibrary;
using System.Windows.Controls;

namespace LinqExamples.Pages.Suppliers.DataTable
{
    /// <summary>
    /// Interaction logic for GetSuppliersByCompanyName.xaml
    /// </summary>
    public partial class GetSuppliersByCompanyName : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetSuppliersByCompanyName()
        {
            InitializeComponent();
            dgData.ItemsSource = sqliteLayer.GetSuppliersTable().DefaultView;
        }

        private void tbInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Data.DataTable suppliers = bl.GetSuppliersByCompanyName(tbInput.Text);

            if (suppliers != null)
            {
                dgData.ItemsSource = suppliers.DefaultView;
                lbErrorMsg.Text = "";
            }
            else
            {
                lbErrorMsg.Text = "No Results Found";
            }
        }
    }
}
