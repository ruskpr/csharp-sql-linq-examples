using ClassLibrary;
using System.Windows.Controls;

namespace LinqExamples.Pages.Products.DataTable
{
    /// <summary>
    /// Interaction logic for GetProductThatNameContains.xaml
    /// </summary>
    public partial class GetProductThatNameContains : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);    
        public GetProductThatNameContains()
        {
            InitializeComponent();

            dgData.ItemsSource = sqliteLayer.GetProductsTable().DefaultView;
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
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
