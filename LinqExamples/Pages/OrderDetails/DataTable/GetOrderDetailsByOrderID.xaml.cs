using ClassLibrary.Sqlite;
using ClassLibrary;
using System.Windows.Controls;

namespace LinqExamples.Pages.OrderDetails.DataTable
{
    /// <summary>
    /// Interaction logic for GetOrderDetailsByOrderID.xaml
    /// </summary>
    public partial class GetOrderDetailsByOrderID : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetOrderDetailsByOrderID()
        {
            InitializeComponent();

            // show full order details table 
            dgData.ItemsSource = sqliteLayer.GetOrderDetailsTable().DefaultView;
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            int orderId;
            bool isValidInteger = int.TryParse(tbInput.Text, out orderId);

            if (isValidInteger)
            {
                System.Data.DataTable? orderDetails = bl.GetOrderDetailsByOrderID(orderId);

                if (orderDetails != null)
                {
                    dgData.ItemsSource = orderDetails.DefaultView;
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
