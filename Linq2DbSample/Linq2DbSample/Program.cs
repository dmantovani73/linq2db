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
            //db.Employees.Take(1).Dump();
            db.Orders.Take(1).Dump();
            //db.OrderDetails.Take(1).Dump();
        }
    }
}