using ClassLibrary.Sqlite;
using ClassLibrary;
using System.Windows.Controls;

namespace LinqExamples.Pages.Products.DataTable
{
    /// <summary>
    /// Interaction logic for GetProductByPriceRange.xaml
    /// </summary>
    public partial class GetProductByPriceRange : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetProductByPriceRange()
        {
            InitializeComponent();

            dgData.ItemsSource = sqliteLayer.GetProductsTable().DefaultView;
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal minValue;
            decimal maxValue;
            
            // if both values in textboxes are decimal values
            if (decimal.TryParse(tbMin.Text, out minValue) && decimal.TryParse(tbMax.Text, out maxValue)) {

                // if both values are valid, show data
                System.Data.DataTable products = bl.GetProductByPriceRange(minValue, maxValue);

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
}
