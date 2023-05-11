using ClassLibrary.Sqlite;
using ClassLibrary.SqlServer;
using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;

namespace ClassLibrary
{
    public class SqlBusinessLayer<T> where T : INorthwindDataLayer
    {
        // this class takes a generic type with the constraint being
        // that the class must implement the 'INorthwindDataLayer' interface

        private INorthwindDataLayer dataLayer;

        public SqlBusinessLayer(string connString)
        {
            if (typeof(T) == typeof(SqlServerDataLayer))
            {
                dataLayer = new SqlServerDataLayer(connString);
            }
            else if (typeof(T) == typeof(SqliteDataLayer))
            {
                dataLayer = new SqliteDataLayer(connString);
            }
            else
            {
                throw new Exception($"The generic type that was passed in was not valid. " +
                    "Must be a class that implements 'INorthwindDataLayer'.");
            }
        }

        public DataTable GetProductThatNameContains(string productName)//
        {
            EnumerableRowCollection<DataRow> query = dataLayer.GetProductsTable()
                .AsEnumerable()
                .Where(p => p.Field<string>("ProductName").ToLower().Contains(productName.ToLower()));

            // convert Enumerable to Datatable
            return query.Count() > 0 ? query.CopyToDataTable() : null;
        }

        public DataTable GetProductByName(string productName)//
        {
            EnumerableRowCollection<DataRow> query = dataLayer.GetProductsTable()
                .AsEnumerable()
                .Where(p => p.Field<string>("ProductName").ToLower() == productName.ToLower());

            // convert Enumerable to Datatable
            return query.Count() > 0 ? query.CopyToDataTable() : null;
        }

        public DataTable GetEmployeeIDFromOrderID(int orderId)//
        {
            // get employeeID from orders table
            int employeeId;
            try
            {
               employeeId = dataLayer.GetOrdersTable()
                                       .AsEnumerable()
                                       .Where(o => o.Field<long>("OrderID") == orderId)
                                       .FirstOrDefault()
                                       .Field<int>("EmployeeID");
            }
            catch
            {
                return null;
            }

            // get employee record using employeeID we got from query above
            var query = dataLayer.GetEmployeesTable()
                .AsEnumerable()
                .Where(employee => employee.Field<long>("EmployeeID") == employeeId);

            return query.Count() > 0 ? query.CopyToDataTable() : null;
        }


        #region Interpret the method name and return all fields as a DataTable for the requested record(s)

        public DataTable GetCustomerByName(string customerName)//
        {
            EnumerableRowCollection<DataRow> query = dataLayer.GetCustomersTable()
                .AsEnumerable()
                .Where(p => p.Field<string>("CompanyName").ToLower() == customerName.ToLower());

            // convert Enumerable to datatable
            if (query.Count() > 0)
                return query.CopyToDataTable();
            else
                return null;
        }

        public DataTable GetProductsByCategoryName(string categoryName)//
        {
            long categoryId;
            try
            {
                 categoryId = dataLayer.GetCategoriesTable()
                .AsEnumerable()
                .Where(category => category.Field<string>("CategoryName").ToLower() == categoryName.ToLower())
                .FirstOrDefault()
                .Field<long>("CategoryID");
            }
            catch 
            {
                return null;
            }
            

            EnumerableRowCollection<DataRow> query = dataLayer.GetProductsTable()
                 .AsEnumerable()
                 .Where(product => product.Field<int>("CategoryID") == categoryId);

            // convert Enumerable to datatable
            return query.Count() > 0 ? query.CopyToDataTable() : null;
        }

        public DataTable GetCustomerByCountry(string country)//
        {
            var query = dataLayer.GetCustomersTable().AsEnumerable().
                Where(customer => customer.Field<string>("Country").ToLower() == country.ToLower());

            return query.Count() > 0 ? query.CopyToDataTable() : null;
        }

        public DataTable GetOrdersByCustomerID(string customerId)//
        {
            var query = dataLayer.GetOrdersTable().AsEnumerable().
                Where(order => order.Field<string>("CustomerID").ToLower() == customerId.ToLower());

            return query.Count() > 0 ? query.CopyToDataTable() : null;
        }

        public DataTable GetOrderDetailsByOrderID(int orderId)
        {
            var query = dataLayer.GetOrderDetailsTable().AsEnumerable().
                Where(orderDetail => orderDetail.Field<int>("OrderID") == orderId);

            return query.Count() > 0 ? query.CopyToDataTable() : null;
        }//

        public DataTable GetOrdersByEmployeeID(int employeeId)//
        {
            var query = dataLayer.GetOrdersTable().AsEnumerable().
                Where(order => order.Field<int>("EmployeeID") == employeeId);

            return query.Count() > 0 ? query.CopyToDataTable() : null;
        }

        public DataTable GetProductByPriceRange(decimal min, decimal max)//
        {
            var query = dataLayer.GetProductsTable().AsEnumerable().
                Where(product => product.Field<decimal>("UnitPrice") > min &&
                                 product.Field<decimal>("UnitPrice") < max);

            return query.Count() > 0 ? query.CopyToDataTable() : null;
        }

        public DataTable GetSuppliersByCompanyName(string companyName)
        {
            var query = dataLayer.GetSuppliersTable().AsEnumerable().
                Where(supplier => supplier.Field<string>("CompanyName").ToLower() == companyName.ToLower());

            return query.Count() > 0 ? query.CopyToDataTable() : null;
        }//
        #endregion

        #region Interpret the method name and return a single value of appropriate data type for the requested record(s):
        public DateTime GetShipDateFromOrder(int orderId)
        {
            DateTime shipDate = dataLayer.GetOrdersTable().AsEnumerable()
                .Where(id => id.Field<long>("OrderID") == orderId)
                .Select(a => a.Field<DateTime>("ShippedDate"))
                .FirstOrDefault();

            return shipDate;
        }//

        public decimal GetMaxProductPrice()//
        {
            var maxPrice = dataLayer.GetProductsTable().AsEnumerable()
                .MaxBy(price => price.Field<decimal>("UnitPrice"));

            return maxPrice.Field<decimal>("UnitPrice");
        }

        public decimal GetMinProductPrice()//
        {
            var minPrice = dataLayer.GetProductsTable().AsEnumerable()
                .MinBy(price => price.Field<decimal>("UnitPrice"));

            return minPrice.Field<decimal>("UnitPrice");
        }

        public int GetOrdersShippedByShipperCount(int shipperId)//
        {
            int ordersShipped = dataLayer.GetOrdersTable().AsEnumerable()
                .Where(id => id.Field<int>("ShipVia") == shipperId)
                .Count();

            return ordersShipped;
        }

        public decimal GetProductPriceByName(string productName)//
        {
            var price = dataLayer.GetProductsTable().AsEnumerable()
                .Where(product => product.Field<string>("ProductName").ToLower() == productName.ToLower())
                .Select(a => a.Field<decimal>("UnitPrice"))
                .FirstOrDefault();

            return price;
        }
        #endregion

        #region Build four methods of your choosing that will classify some data

        // 1 Get Unitprice * unitsInStock by productName
        public decimal GetInventoryValueByProductName(string productName)
        {
            decimal unitPrice = dataLayer.GetProductsTable().AsEnumerable()
                .Where(product => product.Field<string>("ProductName").ToLower() == productName.ToLower())
                .Select(p => p.Field<decimal>("UnitPrice"))
                .FirstOrDefault();

            short unitsInStock = dataLayer.GetProductsTable().AsEnumerable()
                .Where(product => product.Field<string>("ProductName").ToLower() == productName.ToLower())
                .Select(u => u.Field<short>("UnitsInStock"))
                .FirstOrDefault();

            return unitPrice * unitsInStock;
        }

        // 2 Get orderdatebyOrderID
        public DateTime GetOrderDateByOrderID(int orderId)
        {
            DataRow order;
            DateTime orderDate;

            try
            {
                order = dataLayer.GetOrdersTable()
                                  .AsEnumerable()
                                  .Where(o => o.Field<long>("OrderID") == orderId)
                                  .FirstOrDefault();

                orderDate = order.Field<DateTime>("OrderDate");
            }
            catch 
            {
                return DateTime.MinValue;
            }
                              
            return orderDate;
        }

        // 3 get product by orderID
        public DataTable GetProductByOrderID(int orderId)
        {
            int productId;
            try
            {
                productId = dataLayer.GetOrderDetailsTable()
                              .AsEnumerable()
                              .Where(o => o.Field<int>("OrderID") == orderId)
                              .FirstOrDefault()
                              .Field<int>("ProductID");
            }
            catch
            {
                return null;
            }
            

            EnumerableRowCollection<DataRow> query = dataLayer.GetProductsTable()
                .AsEnumerable()
                .Where(p => p.Field<long>("ProductID") == productId);

            // convert Enumerable to Datatable
            return query.Count() > 0 ? query.CopyToDataTable() : null;
        }
        // 4 get orders details by customer id 
        public DataTable GetOrdersDetailsByCustomerID(string customerId)
        {
            long orderId;
            try
            {
                orderId = dataLayer.GetOrdersTable()
                              .AsEnumerable()
                              .Where(o => o.Field<string>("CustomerID").ToLower() == customerId.ToLower())
                              .FirstOrDefault()
                              .Field<long>("OrderID");
            }
            catch
            {
                return null;
            }
            

            EnumerableRowCollection<DataRow> query = dataLayer.GetOrderDetailsTable()
                .AsEnumerable()
                .Where(p => p.Field<int>("OrderId") == orderId);

            // convert Enumerable to Datatable
            return query.Count() > 0 ? query.CopyToDataTable() : null;
        }
        #endregion
    }
}
