using ClassLibrary;
using System.Windows;
using System.Windows.Controls;

namespace LinqExamples.Pages.Products.SingleValue
{
    /// <summary>
    /// Interaction logic for GetMinProductPrice.xaml
    /// </summary>
    public partial class GetMinProductPrice : Page
    {
        SqlBusinessLayer<SqliteDataLayer> bl = new SqlBusinessLayer<SqliteDataLayer>(SqliteDataLayer.DEFAULT_CONN_STRING);
        SqliteDataLayer sqliteLayer = new SqliteDataLayer(SqliteDataLayer.DEFAULT_CONN_STRING);
        public GetMinProductPrice()
        {
            InitializeComponent();

            dgData.ItemsSource = sqliteLayer.GetProductsTable().DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal value = bl.GetMinProductPrice();

            tbReturnValue.Text = value.ToString("c2");
        }
    }
}
