using ClassLibrary.Sqlite;
using ClassLibrary;
using System.Windows;
using System.Windows.Controls;

namespace LinqExamples.Pages.Products.SingleValue
{
    /// <summary>
    /// Interaction logic for GetMaxProductPrice.xaml
    /// </summary>
    public partial class GetMaxProductPrice : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetMaxProductPrice()
        {
            InitializeComponent();

            dgData.ItemsSource = sqliteLayer.GetProductsTable().DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal value = bl.GetMaxProductPrice();

            tbReturnValue.Text = value.ToString("c2");
        }
    }
}
