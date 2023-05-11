using ClassLibrary.Sqlite;
using ClassLibrary;
using System.Windows.Controls;

namespace LinqExamples.Pages.Products.DataTable
{
    /// <summary>
    /// Interaction logic for GetProductByCategoryName.xaml
    /// </summary>
    public partial class GetProductByCategoryName : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetProductByCategoryName()
        {
            InitializeComponent();

            // show full products table 
            dgData.ItemsSource = sqliteLayer.GetProductsTable().DefaultView;
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Data.DataTable? products = bl.GetProductsByCategoryName(tbCategoryName.Text);

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
