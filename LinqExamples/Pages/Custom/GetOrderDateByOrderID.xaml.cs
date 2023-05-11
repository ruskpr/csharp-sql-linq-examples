using ClassLibrary.Sqlite;
using ClassLibrary;
using System;
using System.Windows.Controls;

namespace LinqExamples.Pages.Custom
{
    /// <summary>
    /// Interaction logic for GetOrderDateByOrderID.xaml
    /// </summary>
    public partial class GetOrderDateByOrderID : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetOrderDateByOrderID()
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
                DateTime orderDate = bl.GetOrderDateByOrderID(orderId);

                tbReturnValue.Text = orderDate.Year != 0001 ? orderDate.ToString() : "Invalid Order ID";
            }
        }
    }
}
