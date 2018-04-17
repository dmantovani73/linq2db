using LinqToDB.DataProvider.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linq2DbSample.Tests
{
    [TestClass]
    public class NorthwindTests
    {
        static readonly IDataContextFactory<NorthwindDataContext> dbFactory = new NorthwindDataContextFactory(
            dataProvider: SQLiteTools.GetDataProvider(),
            connectionString: "Data Source=Northwind_small.sqlite"
        );

        NorthwindDataContext db;

        [TestInitialize]
        public void Initialize()
        {
            db = dbFactory.Create();
        }

        [TestCleanup]
        public void Cleanup()
        {
            db?.Dispose();
        }

        [TestMethod]
        public void total_units_in_stock_for_products_of_category_4()
        {
            var units = db.TotalUnitsInStockForProductsOfCategory(4);
            Assert.AreEqual(units, 393);
        }
    }
}
