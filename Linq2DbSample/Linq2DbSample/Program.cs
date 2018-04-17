using LinqToDB.DataProvider.SQLite;

class Program
{
    static readonly IDataContextFactory<NorthwindDataContext> dbFactory = new NorthwindDataContextFactory(
        dataProvider: SQLiteTools.GetDataProvider(),
        connectionString: "Data Source=Northwind_small.sqlite"
    );

    static void Main(string[] args)
    {
        using (var db = dbFactory.Create())
        {
            var q = db.TotalUnitsInStockForProductsOfCategory(4);
            //var q = db.EmployeesThasHaventBoss();
            //var q = db.NumberOfCollaborators();

            db.DumpQuery(q);
        }
    }
}