using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SqliteDataLayer : INorthwindDataLayer
    {
        public static string DEFAULT_CONN_STRING = $"Data source={Path.Combine(Environment.CurrentDirectory, "nw.db")}";

        string connectionString = "";

        public SqliteDataLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #region SELECT * datatable methods
        public DataTable GetOrdersTable()
        {
            return GetDataTableFromQuery("SELECT * FROM Orders");
        }
        public DataTable GetCategoriesTable()
        {
            return GetDataTableFromQuery("SELECT * FROM Categories");
        }

        public DataTable GetCustomersTable()
        {
            return GetDataTableFromQuery("SELECT * FROM Customers");
        }

        public DataTable GetEmployeesTable()
        {
            return GetDataTableFromQuery("SELECT * FROM Employees");
        }

        public DataTable GetOrderDetailsTable()
        {
            return GetDataTableFromQuery("SELECT * FROM [Order Details]");
        }

        public DataTable GetProductsTable()
        {
            return GetDataTableFromQuery("SELECT * FROM Products");
        }

        public DataTable GetRegionsTable()
        {
            return GetDataTableFromQuery("SELECT * FROM Region");
        }

        public DataTable GetShippersTable()
        {
            return GetDataTableFromQuery("SELECT * FROM Shippers");
        }

        public DataTable GetSuppliersTable()
        {
            return GetDataTableFromQuery("SELECT * FROM Suppliers");
        }

        public DataTable GetTerritoriesTable()
        {
            return GetDataTableFromQuery("SELECT * FROM Territories");
        }
        #endregion

        private DataTable GetDataTableFromQuery(string qry)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    SQLiteCommand cmd = new SQLiteCommand(qry, conn);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (SQLiteException e)
            {
                Debug.WriteLine(e.Message);
                throw;
                //return null;
            }

            return dt;
        }
    }
}
