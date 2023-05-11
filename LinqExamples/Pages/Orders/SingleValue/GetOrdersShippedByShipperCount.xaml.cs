using ClassLibrary.Sqlite;
using ClassLibrary;
using System.Windows.Controls;

namespace LinqExamples.Pages.Orders.SingleValue
{
    /// <summary>
    /// Interaction logic for GetOrdersShippedByShipperCount.xaml
    /// </summary>
    public partial class GetOrdersShippedByShipperCount : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetOrdersShippedByShipperCount()
        {
            InitializeComponent();

            dgData.ItemsSource = sqliteLayer.GetShippersTable().DefaultView;
        }

        private void tbInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            int shipperId;
            bool isValidInteger = int.TryParse(tbInput.Text, out shipperId);

            if (isValidInteger)
            {
                int ordersMade = bl.GetOrdersShippedByShipperCount(shipperId);

                tbReturnValue.Text = ordersMade > 0 ? ordersMade.ToString() : "None";
            }
        }
    }
}
