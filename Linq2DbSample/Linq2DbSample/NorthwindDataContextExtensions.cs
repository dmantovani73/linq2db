using LinqToDB;
using System.Linq;

public static class NorthwindDataContextExtensions
{
    public static void DumpAllTables(this NorthwindDataContext db)
    {
        db.Customers.Take(1).Dump();
        db.Employees.LoadWith(e => e.Boss).Dump();
        db.Orders.LoadWith(e => e.Customer).LoadWith(e => e.Employee).Take(1).Dump();
        db.OrderDetails.LoadWith(e => e.Order).LoadWith(e => e.Product).Take(1).Dump();
        db.Products.LoadWith(e => e.Supplier).LoadWith(e => e.Category).Take(1).Dump();
        db.Suppliers.Take(1).Dump();
        db.Categories.Take(1).Dump();
    }

    /// <summary>
    /// Numero totale di unità in stock relativamente ai prodotti di una certa categoria.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    public static long TotalUnitsInStockForProductsOfCategory(this NorthwindDataContext db, long categoryId) => (
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
    public static IQueryable<Employee> EmployeesThasHaventBoss(this NorthwindDataContext db) =>
        from e in db.Employees
        where e.ReportsTo == null
        select e;

    /// <summary>
    /// Per ogni impiegato che ha collaboratori indicarne nome, cognome e numero di collaboratori.
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public static IQueryable<EmployeeCollaborator> NumberOfCollaborators(this NorthwindDataContext db) =>
        from e in db.Employees
        join p in db.Employees on e.ReportsTo equals p.Id
        group e by new { p.FirstName, p.LastName }
            into g
            let boss = g.Key
            select new EmployeeCollaborator
            {
                FirstName = boss.FirstName,
                LastName = boss.LastName,
                CollaboratorsCount = g.Count()
            };

    static void CreateTable(NorthwindDataContext db)
    {
        db.CreateTableIfNotExists<Person>();
        db.DeleteAll<Person>();

        db.InsertWithInt32Identity(new Person { FirstName = "John", LastName = "Smith", Age = 30 });
        db.InsertWithInt32Identity(new Person { FirstName = "Jim", LastName = "Johnson" });

        db.DumpQuery(db.GetTable<Person>());
    }
}