using ClassLibrary.Sqlite;
using ClassLibrary;
using System.Windows.Controls;

namespace LinqExamples.Pages.Custom
{
    /// <summary>
    /// Interaction logic for GetInventoryValueByProductName.xaml
    /// </summary>
    public partial class GetInventoryValueByProductName : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetInventoryValueByProductName()
        {
            InitializeComponent();

            dgData.ItemsSource = sqliteLayer.GetProductsTable().DefaultView;
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbOutput.Text = bl.GetInventoryValueByProductName(tbProductName.Text).ToString("c2");

            System.Data.DataTable products = bl.GetProductThatNameContains(tbProductName.Text);
            if (products != null)
            {
                dgData.ItemsSource = products.DefaultView;
                lbErrorMsg.Text = "";
            }
            else
            {
                lbErrorMsg.Text = "No Records Found";
            }
        }
    }
}
