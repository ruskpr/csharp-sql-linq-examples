using System.Data;

namespace ClassLibrary;

public interface INorthwindDataLayer
{
    DataTable GetCategoriesTable();
    DataTable GetCustomersTable();
    DataTable GetEmployeesTable();
    DataTable GetOrderDetailsTable();
    DataTable GetOrdersTable();
    DataTable GetProductsTable();
    DataTable GetRegionsTable();
    DataTable GetShippersTable();
    DataTable GetSuppliersTable();
    DataTable GetTerritoriesTable();
}