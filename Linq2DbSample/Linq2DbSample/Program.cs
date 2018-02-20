using LinqToDB;
using LinqToDB.DataProvider;
using LinqToDB.DataProvider.SQLite;
using System.Linq;

class Program
{
    const string ConnectionString = "Data Source=Northwind_small.sqlite";

    static readonly IDataProvider DataProvider = SQLiteTools.GetDataProvider();

    static void Main(string[] args)
    {
        using (var db = new NorthwindDataContext(DataProvider, ConnectionString))
        {
            //db.Customers.Take(1).Dump();
            //db.Employees.LoadWith(e => e.Boss).Dump();
            //db.Orders.LoadWith(e => e.Customer).LoadWith(e => e.Employee).Take(1).Dump();
            //db.OrderDetails.LoadWith(e => e.Order).LoadWith(e => e.Product).Take(1).Dump();
            //db.Products.LoadWith(e => e.Supplier).LoadWith(e => e.Category).Take(1).Dump();
            //db.Suppliers.Take(1).Dump();
            //db.Categories.Take(1).Dump();
        }
    }
}