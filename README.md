# WPF Application with LINQ Examples

This is a WPF (Windows Presentation Foundation) application that demonstrates the usage of LINQ (Language Integrated Query) in C#. It manipulates SQL data from Microsoft's sample database (Northwind).

LINQ is a powerful query language that provides a unified syntax for querying and manipulating data from different data sources.

- Here is an example of a query that is used in the codebase:

```csharp
public DataTable GetProductByPriceRange(decimal min, decimal max)
{
    var query = dataLayer.GetProductsTable().AsEnumerable().
        Where(product => product.Field<decimal>("UnitPrice") > min &&
                         product.Field<decimal>("UnitPrice") < max);

    return query.Count() > 0 ? query.CopyToDataTable() : null;
}
```

- And this is what it looks like in the application:

<img src="https://github.com/ruskpr/csharp-sql-linq-examples/blob/main/Images/example-query.png" data-canonical-src="https://github.com/ruskpr/csharp-sql-linq-examples/blob/main/Images/example-query.png" width="600" height="400" />

## Setup

1. Clone or download this repository to your local machine.
2. Open the solution file `LinqExamples.sln` in Visual Studio.
3. Build the solution to restore NuGet packages and run the application.
- The SQL database is already configured and is already included in the project, so you are not required to do any database configurations.

## Usage

1. Select the desired LINQ example from the sidebar menu.
2. Enter values into the corresponding inputs to see the updated data.
