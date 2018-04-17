using LinqToDB.DataProvider.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

        [TestMethod]
        public void employees_thas_havent_boss()
        {
            var employees = db.EmployeesThasHaventBoss();
            Assert.IsTrue(employees.First().Id == 2);
        }

        [TestMethod]
        public void number_of_collaborators()
        {
            var collaborators = db.NumberOfCollaborators();

            Assert.IsTrue(collaborators.First(c => c.FirstName == "Andrew" && c.LastName == "Fuller").CollaboratorsCount == 5);
            Assert.IsTrue(collaborators.First(c => c.FirstName == "Steven" && c.LastName == "Buchanan").CollaboratorsCount == 3);
        }
    }
}
