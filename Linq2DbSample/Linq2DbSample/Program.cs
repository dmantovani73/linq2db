using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider;
using LinqToDB.DataProvider.SQLite;
using System;
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

            //var q = TotalUnitsInStockForProductsOfCategory(db, 4);
            //var q = EmployeesThasHaventBoss(db);
            var q = NumberOfCollaborators(db);

            DumpQuery(db, q);
        }
    }

    /// <summary>
    /// Numero totale di unità in stock relativamente ai prodotti di una certa categoria.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    static long TotalUnitsInStockForProductsOfCategory(NorthwindDataContext db, long categoryId) => (
        from p in db.Products
        join c in db.Categories on p.CategoryId equals c.Id
        where p.CategoryId == 4
        select new { p.Id, p.ProductName, p.CategoryId, c.CategoryName, p.UnitsInStock }
    ).Sum(e => e.UnitsInStock);

    /// <summary>
    /// Impiegati che non hanno un capo.
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    static IQueryable<Employee> EmployeesThasHaventBoss(NorthwindDataContext db) =>
        from e in db.Employees
        where e.ReportsTo == null
        select e;

    /// <summary>
    /// Per ogni impiegato che ha collaboratori indicarne nome, cognome e numero di collaboratori.
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    static IQueryable<object> NumberOfCollaborators(NorthwindDataContext db) =>
        from e in db.Employees
        join p in db.Employees on e.ReportsTo equals p.Id
        group e by new { p.FirstName, p.LastName }
            into g
            let boss = g.Key
            select new { boss.FirstName, boss.LastName, CollaboratorsCount = g.Count() };

    static void DumpQuery<T>(DataConnection db, T query)
    {
        query.Dump();

        Console.WriteLine();
        Console.WriteLine(db.LastQuery);
    }
}