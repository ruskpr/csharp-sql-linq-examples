using ClassLibrary;
using System;
using System.Windows.Controls;

namespace LinqExamples.Pages.Orders.SingleValue
{
    /// <summary>
    /// Interaction logic for GetShipDateFromOrder.xaml
    /// </summary>
    public partial class GetShipDateFromOrder : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetShipDateFromOrder()
        {
            InitializeComponent();

            dgData.ItemsSource = sqliteLayer.GetOrdersTable().DefaultView;
        }

        private void tbInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            int orderId;
            bool isValidInteger = int.TryParse(tbInput.Text, out orderId);

            if (isValidInteger)
            {
                DateTime shipDate = bl.GetShipDateFromOrder(orderId);

                tbReturnValue.Text = shipDate.Year != 0001 ? shipDate.ToString() : "Invalid Order ID";
            }
        }
    }
}
