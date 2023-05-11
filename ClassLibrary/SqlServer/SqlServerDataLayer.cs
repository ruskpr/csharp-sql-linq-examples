using System;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary.SqlServer
{
    public class SqlServerDataLayer : INorthwindDataLayer
    {
        // TODO: Target your SQL Server instance (if you plan to use SQL Server)
        public static string DEFAULT_CONN_STRING = "server=localhost;database=Northwind;user id=sa;password=P@ssword!;encrypt=false";

        string connectionString = "";

        public SqlServerDataLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #region Select * from [table] queries
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
        public DataTable GetOrdersTable()
        {
            return GetDataTableFromQuery("SELECT * FROM Orders");
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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(qry, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                return null;
            }

            return dt;
        }
    }
}