using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider;

class NorthwindDataContext : DataConnection
{
    public NorthwindDataContext(IDataProvider dataProvider, string connectionString)
        : base(dataProvider, connectionString)
    { }

    public ITable<Employee> Employees => GetTable<Employee>();

    public ITable<Customer> Customers => GetTable<Customer>();

    public ITable<Order> Orders => GetTable<Order>();

    public ITable<OrderDetail> OrderDetails => GetTable<OrderDetail>();

    public ITable<Product> Products => GetTable<Product>();

    public ITable<Supplier> Suppliers => GetTable<Supplier>();

    public ITable<Category> Categories => GetTable<Category>();
}