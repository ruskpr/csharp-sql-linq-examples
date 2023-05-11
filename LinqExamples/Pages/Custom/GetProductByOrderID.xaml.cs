using ClassLibrary;
using System.Windows.Controls;

namespace LinqExamples.Pages.Custom
{
    /// <summary>
    /// Interaction logic for GetProductByOrderID.xaml
    /// </summary>
    public partial class GetProductByOrderID : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetProductByOrderID()
        {
            InitializeComponent();

            // show full products table 
            dgData.ItemsSource = sqliteLayer.GetProductsTable().DefaultView;
        }

        private void tbInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            int orderId;
            bool isValidInteger = int.TryParse(tbInput.Text, out orderId);

            if (isValidInteger)
            {
                System.Data.DataTable? products = bl.GetProductByOrderID(orderId);

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
